using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Xml;

namespace FalconDatabase.Files
{
    /// <summary>
    /// The Class Table Database contained in the FALCON4_CT.xml File.
    /// </summary>
    public class ClassTable : AppFile, IEquatable<ClassTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="ClassEntityDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<ClassEntityDefinition> Classes { get => dbObjects; set => dbObjects = value; }
        /// <summary>
        /// Class Table Element of the Database in Raw Data Format.
        /// </summary>
        public DataTable ClassDataTable 
        {
            get
            {
                DataSet dataSet = new();
                dataSet.ReadXmlSchema(schemaFile);
                DataTable table = dataSet.Tables[0];
                foreach (var entry in dbObjects)
                {
                    table.Rows.Add(entry.ToDataRow());
                }
                return table;
            }
        }
        /// <summary>
        /// <para>When <see langword="true"/>, indicates this <see cref="AppFile"/> was successfully loaded from the file.</para>
        /// <para><see langword="false"/> indicates there were no values in the initialization data used for this <see cref="AppFile"/> object and empty or default values were loaded instead.</para>
        /// </summary>
        public override bool IsDefaultInitialization { get => dbObjects.Count > 0; }
        #endregion Properties

        #region Fields
        private Collection<ClassEntityDefinition> dbObjects = [];
        private readonly string schemaFile =
            Path.Combine(Path.GetDirectoryName(path: Assembly.GetExecutingAssembly().Location ?? Environment.CurrentDirectory), @"XMLSchemas\CT.xsd");
        #endregion Fields

        #region Helper Methods               
        /// <summary>
        /// Processes the XML Data in <paramref name="data"/> and attempts to convert it into a <see cref="DataTable"/> with values read from <paramref name="data"/>.
        /// </summary>
        /// <param name="data">XML Data read from a Database File in the ..\TerrData\Objects\ Directory.</param>
        /// <returns><see langword="true"/> if the File is successfully read and parsed. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected override bool Read(string data)
        {
            ArgumentException.ThrowIfNullOrEmpty(data);
            using StringReader reader = new(data);
            try
            {
                DataSet ds = new();
                ds.ReadXmlSchema(schemaFile);
                ds.ReadXml(reader, XmlReadMode.ReadSchema);
                foreach (DataRow row in ds.Tables[0].Rows) dbObjects.Add(new(row));
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading the CT Table.");
                reader.Close();
                throw;
            }

            return IsDefaultInitialization;
        }
        /// <summary>
        /// Formats the File Contents into bytes for writing to disk.
        /// </summary>
        /// <returns><see cref="byte"/> array suitable for writing to a file.</returns>
        protected override byte[] Write()
        {
            DataSet ds = new();
            ds.ReadXmlSchema(schemaFile);

            using MemoryStream stream = new();
            using XmlWriter writer = XmlWriter.Create(stream);
            try
            {
                foreach (var entry in dbObjects)
                    ds.Tables[0].Rows.Add(entry.ToDataRow());

                ds.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                stream.Write(Encoding.UTF8.GetBytes(Environment.NewLine));
                stream.Position = 0;
                return Encoding.UTF8.GetBytes(new StreamReader(stream).ReadToEnd());
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while writing the CT Table.");
                stream.Close();
                throw;
            }
        }

        #endregion Helper Methods

        #region Functional Methods

        /// <summary>
        /// Formats the Data in this Table for Generic Text Output.
        /// </summary>
        /// <returns><para><see cref="string"/> object with the data from this object.</para>
        /// <para>NOTE: This does not format the Database file for XML Output.</para></returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append("***** Class Table *****");
            foreach (var entry in dbObjects)
                sb.Append(entry.ToString());

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            ClassTable? comparator = other as ClassTable;
            if (comparator is null)
                return false;
            else
                return Equals(comparator);
        }
        public override int GetHashCode()
        {

            unchecked
            {
                int hash = 2539;
                for (int i = 0; i < Classes.Count; i++)
                    hash = hash * 5483 + Classes[i].GetHashCode();
                return hash;
            }

        }
        public bool Equals(ClassTable? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;

            return other.ToString() == ToString() && other.GetHashCode() == GetHashCode();
        }
        #endregion Equality Functions

        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="ClassTable"/> object.
        /// </summary>
        public ClassTable()
        {
            _FileType = ApplicationFileType.DatabaseCT;
            _StreamType = FileStreamType.XML;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="ClassTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public ClassTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors

    }
   
}
