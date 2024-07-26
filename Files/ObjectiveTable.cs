using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Files
{
    /// <summary>
    /// An Objective in the Database.
    /// </summary>
    public class ObjectiveTable : AppFile, IEquatable<ObjectiveTable>
    {
        #region Properties
        /// <summary>
        /// A Collection of <see cref="ObjectiveDefinition"/> objects.
        /// </summary>
        public Collection<ObjectiveDefinition> Objectives { get => dbObjects; set => dbObjects = value; }  
        /// <summary>
        /// A <see cref="DataSet"/> with all of the Objective Data.
        /// </summary>
        public DataSet ObjectiveDataSet
        {
            get
            {
                DataSet dataSet = new();
                dataSet.ReadXmlSchema(schemaFile);
                dataSet.ReadXmlSchema(schemaFile.Replace("OCD", "FED"));
                dataSet.ReadXmlSchema(schemaFile.Replace("OCD", "PDX"));
                dataSet.ReadXmlSchema(schemaFile.Replace("OCD", "PDH"));
                foreach (var entry in dbObjects)
                {
                    dataSet.Tables[0].Rows.Add(entry.ToDataRow().ItemArray);
                    foreach (var feature in entry.Features)
                        dataSet.Tables[1].Rows.Add(feature.ToDataRow().ItemArray);
                    foreach (var point in entry.Points)
                        dataSet.Tables[2].Rows.Add(point.ToDataRow().ItemArray);
                    foreach (var header in entry.HeaderData)
                        dataSet.Tables[3].Rows.Add(header.ToDataRow().ItemArray);
                }
                return dataSet;
            }
        }
        /// <summary>
        /// <para>When <see langword="true"/>, indicates this <see cref="AppFile"/> was successfully loaded from the file.</para>
        /// <para><see langword="false"/> indicates there were no values in the initialization data used for this <see cref="AppFile"/> object and empty or default values were loaded instead.</para>
        /// </summary>
        public override bool IsDefaultInitialization { get => dbObjects.Count > 0; }
        
        #endregion Properties

        #region Fields   
        private Collection<ObjectiveDefinition> dbObjects = [];
        private readonly string schemaFile =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\OCD.xsd");
        private DirectoryInfo? dbLocation = null;
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

            dbLocation = new(data);
            // ObjectiveRelatedData\            
            Collection<DirectoryInfo> objs = new(dbLocation.GetDirectories());
            int index = 0;
            foreach (DirectoryInfo dir in objs)
            {
                
                FileInfo objFile = dir.GetFiles("*OCD*")[0];
                FileInfo fedFile = dir.GetFiles("*FED*")[0];
                FileInfo pdxFile = dir.GetFiles("*PDX*")[0];
                FileInfo phdFile = dir.GetFiles("*PHD*")[0];
                using StringReader reader = new(File.ReadAllText(objFile.FullName));
                try
                {
                    DataSet ds = new();
                    ds.ReadXmlSchema(schemaFile);
                    ds.ReadXml(reader, XmlReadMode.ReadSchema);
                    
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
#if DEBUG
                        Trace.WriteLine("Adding Objective: " + index);
#endif
                        ObjectiveDefinition obj = new(row);
#if DEBUG
                        Trace.WriteLine("Adding Features: " + index);
#endif
                        using StringReader fReader = new(File.ReadAllText(fedFile.FullName));
                        DataSet fds = new();
                        fds.ReadXmlSchema(schemaFile.Replace("OCD", "FED"));
                        fds.ReadXml(fReader, XmlReadMode.ReadSchema);
                        foreach (DataRow row2 in fds.Tables[0].Rows)
                            obj.Features.Add(new(row2));
                        fReader.Close();

#if DEBUG
                        Trace.WriteLine("Adding Points: " + index);
#endif
                        using StringReader pReader = new(File.ReadAllText(pdxFile.FullName));
                        DataSet pxds = new();
                        pxds.ReadXmlSchema(schemaFile.Replace("OCD", "PDX"));
                        pxds.ReadXml(pReader, XmlReadMode.ReadSchema);
                        foreach (DataRow row2 in pxds.Tables[0].Rows)
                            obj.Points.Add(new(row2));
                        pReader.Close();

#if DEBUG
                        Trace.WriteLine("Adding Headers: " + index++);
#endif
                        using StringReader hReader = new(File.ReadAllText(phdFile.FullName));
                        DataSet hds = new();
                        hds.ReadXmlSchema(schemaFile.Replace("OCD", "PHD"));
                        hds.ReadXml(hReader, XmlReadMode.ReadSchema);
                        foreach (DataRow row2 in hds.Tables[0].Rows)
                            obj.HeaderData.Add(new(row2));
                        hReader.Close();

                        dbObjects.Add(obj);

                    }                        
                   
                }
                catch (Exception ex)
                {
                    Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an OCD Table.");
                    reader.Close();
                    throw;
                }                

            }

            return dbObjects.Count > 0;
        }
        /// <summary>
        /// Formats the File Contents into bytes for writing to disk.
        /// </summary>
        /// <returns><see cref="byte"/> array suitable for writing to a file.</returns>
        protected override byte[] Write()
        {
            
            for (int i = 0; i < Objectives.Count; i++)
            {
                DataSet ds = new();
                ds.ReadXmlSchema(schemaFile);
                string path = dbLocation + "\\OCD_" + i.ToString("D5") + "\\"; 
                try
                {
                    ds.Tables[0].Rows.Add(Objectives[i].ToDataRow().ItemArray);
                    ds.WriteXml(path+"\\OCD_" + i.ToString("D5") + ".xml", XmlWriteMode.IgnoreSchema);
                    
                    DataSet dsf = new();
                    foreach (var feature in Objectives[i].Features)
                        dsf.Tables[0].Rows.Add(feature.ToDataRow().ItemArray);
                    dsf.ReadXmlSchema(schemaFile.Replace("OCD", "FED"));
                    dsf.WriteXml(path + "\\FED_" + i.ToString("D5") + ".xml");

                    DataSet dspx = new();
                    foreach (var point in Objectives[i].Points)
                        dspx.Tables[0].Rows.Add(point.ToDataRow().ItemArray);
                    dsf.ReadXmlSchema(schemaFile.Replace("OCD", "PDX"));
                    dsf.WriteXml(path + "\\PDX_" + i.ToString("D5") + ".xml");

                    DataSet dsph = new();
                    foreach (var point in Objectives[i].HeaderData)
                        dsph.Tables[0].Rows.Add(point.ToDataRow().ItemArray);
                    dsf.ReadXmlSchema(schemaFile.Replace("OCD", "PHD"));
                    dsf.WriteXml(path + "\\PHD_" + i.ToString("D5") + ".xml");
                }
                catch (Exception ex)
                {
                    Utilities.Logging.ErrorLog.CreateLogFile(ex, "This error occurred while writing the Objective Database.");
                    return [0];
                }

            }

            return [1];
            
        }
        /// <summary>
        /// Sets the output location for the Objective Database.
        /// </summary>
        /// <param name="outputLocation"></param>
        private void SetOutputLocation(string outputLocation)
        {
            if (Directory.Exists(outputLocation))
                dbLocation = new DirectoryInfo(outputLocation);
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
            sb.AppendLine("***** Objective Table *****");
            foreach (ObjectiveDefinition obj in Objectives)
                sb.Append(obj.ToString());
            return sb.ToString();
        }
        /// <summary>
        /// Saves the <see cref="ObjectiveTable"/> to the Folder supplied in <paramref name="path"/>.
        /// </summary>
        /// <param name="path">A Folder to save the Objective Database to. 
        /// Output will conform to the current practice of creating a Directory for each Objective containing the OCD, FED, PDX, and PHD files.</param>
        /// <returns></returns>
        public override bool Save(string path)
        {
            SetOutputLocation(path);
            byte[] result = Write();
            return result[0] == 1;
        }

        #region Equality Functions        
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            if (other is not ObjectiveTable comparator)
                return false;
            else
                return Equals(comparator);
        }
        public override int GetHashCode()
        {

            unchecked
            {
                int hash = 2539;
                //for (int i = 0; i < dbTable.Rows.Count; i++)
                  //  hash = hash * 5483 + dbTable.Rows[i].GetHashCode();
                return hash;
            }

        }
        public bool Equals(ObjectiveTable? other)
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
        /// Default Constructor for the <see cref="ObjectiveTable"/> object.
        /// </summary>
        public ObjectiveTable() 
        {
            _FileType = ApplicationFileType.DatabaseOCD;
            _StreamType = FileStreamType.DirectoryName;
            _IsCompressed = false;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ObjectiveTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public ObjectiveTable(string filePath)
            : this()
        {
            if (Directory.Exists(filePath))
                Load(filePath);            
        }
        #endregion Constructors
    }
}
