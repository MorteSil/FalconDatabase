using FalconDatabase.Enums;
using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace FalconDatabase.Files
{
    /// <summary>
    /// The Sim Weapon Database contained in the FALCON4_SWD.xml File.
    /// </summary>
    public class SimWeaponTable : GameFile, IEquatable<SimWeaponTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="SimWeaponDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<SimWeaponDefinition> WeaponDefinitions
        {
            get
            {
                Collection<SimWeaponDefinition> output = new();
                foreach (DataRow row in dbTable.Rows)
                    output.Add(ToWeaponDefinitions(row));

                return output;
            }
        }
        /// <summary>
        /// Weapon Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable Weapons { get => dbTable; set => dbTable = value; }
        /// <summary>
        /// <para>When <see langword="true"/>, indicates this <see cref="GameFile"/> was successfully loaded from the file.</para>
        /// <para><see langword="false"/> indicates there were no values in the initialization data used for this <see cref="GameFile"/> object and empty or default values were loaded instead.</para>
        /// </summary>
        public override bool IsDefaultInitialization { get => dbTable.Rows.Count > 0; }
        #endregion Properties

        #region Fields
        private DataTable dbTable = new();
        #endregion Fields

        #region Helper Methods

        /// <summary>
        /// Converts a <see cref="DataRow"/> with correct values into a native Falcon Object.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with appropriate initializaiton data values.</param>
        /// <returns></returns>
        private static SimWeaponDefinition ToWeaponDefinitions(DataRow row)
        {
            try
            {
                int index = 0;
                SimWeaponDefinition output = new()
                {
                    Flags = int.Parse((string)row[index++]),
                    DragCoefficient = float.Parse((string)row[index++]),
                    Weight = float.Parse((string)row[index++]),
                    Area = float.Parse((string)row[index++]),
                    XEjection = float.Parse((string)row[index++]),
                    YEjection = float.Parse((string)row[index++]),
                    ZEjection = float.Parse((string)row[index++]),
                    SMSMnemonic = (string)row[index++],
                    WeaponClass = int.Parse((string)row[index++]),
                    Domain = int.Parse((string)row[index++]),
                    WeaponType = int.Parse((string)row[index++]),
                    WeaponID = int.Parse((string)row[index++])
                };

                return output;
            }
            catch (Exception ex)
            { return null; }

        }
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
                // DataSet can auto configure the XML Schema
                DataSet table = new();
                table.ReadXml(reader);
                dbTable = table.Tables[0];
            }
            catch (Exception ex)
            {
                reader.Close();
                throw;
            }

            return dbTable.Rows.Count > 0;
        }
        /// <summary>
        /// Formats the File Contents into bytes for writing to disk.
        /// </summary>
        /// <returns><see cref="byte"/> array suitable for writing to a file.</returns>
        protected override byte[] Write()
        {
            using MemoryStream stream = new MemoryStream();
            try
            {
                stream.Write(Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine));
                dbTable.WriteXml(stream);
                stream.Write(Encoding.UTF8.GetBytes(Environment.NewLine));
                stream.Position = 0;
                return Encoding.UTF8.GetBytes(new StreamReader(stream).ReadToEnd());
            }
            catch (Exception ex)
            {
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
            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in dbTable.Rows)
            {
                sb.AppendLine("***** Weapon Table Entry *****");
                sb.Append(ToWeaponDefinitions(row).ToString());
            }

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            SimWeaponTable? comparator = other as SimWeaponTable;
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
                for (int i = 0; i < dbTable.Rows.Count; i++)
                    hash = hash * 5483 + dbTable.Rows[i].GetHashCode();
                return hash;
            }

        }
        public bool Equals(SimWeaponTable? other)
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
        /// Default Constructor for the <see cref="SimWeaponTable"/> object.
        /// </summary>
        public SimWeaponTable()
        {
            _FileType = GameFileType.DatabaseSWD;
            _StreamType = FileStreamType.XML;
            _IsFileModified = false;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="SimWeaponTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public SimWeaponTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors

    }
}
