using FalconDatabase.Enums;
using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Xml;

namespace FalconDatabase.Files
{
    /// <summary>
    /// The Squadron Stores Database contained in the FALCON4_SSD.xml File.
    /// </summary>
    public class SquadronStoresTable : GameFile, IEquatable<SquadronStoresTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="SquadronStoresDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<SquadronStoresDefinition> SquadronStoresDefinitions
        {
            get
            {
                Collection<SquadronStoresDefinition> output = new();
                foreach (DataRow row in dbTable.Rows)
                    output.Add(ToSquadronStoresDefinition(row));

                return output;
            }
        }
        /// <summary>
        /// Squadron Stores Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable SquadronStores { get => dbTable; set => dbTable = value; }
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
        private static SquadronStoresDefinition ToSquadronStoresDefinition(DataRow row)
        {

            try
            {

                SquadronStoresDefinition output = new()
                {
                    InfiniteAG = byte.Parse((string)row[0]),
                    InfiniteAA = byte.Parse((string)row[1]),
                    InfiniteGun = byte.Parse((string)row[2]),
                    Stores = (Dictionary<int, int?>)row[4]
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

            using StringReader reader = new StringReader(data);
            try
            {
                DataSet table = new();
                table.ReadXml(reader);
                table.Tables[0].Columns.Add("StoresDictionary", typeof(Dictionary<int, int?>));


                for (int i = 0; i < table.Tables[0].Rows.Count; i++)
                {
                    Dictionary<int, int?> values = new Dictionary<int, int?>();
                    DataRow row = table.Tables[0].Rows[i];
                    for (int j = 0; j < 2000; j++)
                    {
                        values.Add(j, 0);
                        if (table.Tables[0].Columns.Contains("WpnStores_" + j) && row["WpnStores_" + j] != DBNull.Value)
                        {
                            int key = j;
                            int? val;
                            val = int.Parse((string)row["WpnStores_" + j]);
                            values[j] = val == null ? 0 : val;
                        }
                    }
                    row["StoresDictionary"] = values;
                }
                for (int i = 0; i < 2000; i++)
                {
                    if (table.Tables[0].Columns.Contains("WpnStores_" + i))
                        table.Tables[0].Columns.Remove("WpnStores_" + i);
                }

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
            SquadronStoresDefinition[] stores = SquadronStoresDefinitions.ToArray();
            using MemoryStream stream = new MemoryStream();
            try
            {
                XmlWriter writer = XmlWriter.Create(stream);
                writer.WriteStartDocument();
                writer.WriteStartElement("SSDRecords");
                for (int i = 0; i < stores.Length; i++)
                {
                    writer.WriteStartElement("SSD");
                    writer.WriteAttributeString("Num", i.ToString());
                    for (int j = 0; j < stores[i].Stores.Count; j++)
                    {
                        if (stores[i].Stores[j] != null && stores[i].Stores[j] != 0)
                        {
                            writer.WriteStartElement("WpnStores_" + j.ToString());
                            writer.WriteString(stores[i].Stores[j].ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteStartElement("InfiniteAG");
                        writer.WriteString(stores[i].InfiniteAG.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("InfiniteAA");
                        writer.WriteString(stores[i].InfiniteAA.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("InfiniteGun");
                        writer.WriteString(stores[i].InfiniteGun.ToString());
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                stream.Write(Encoding.UTF8.GetBytes(Environment.NewLine));
                writer.Close();
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
                sb.AppendLine("***** Rocket Table Entry *****");
                sb.Append(ToSquadronStoresDefinition(row).ToString());
            }

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            SquadronStoresTable? comparator = other as SquadronStoresTable;
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
        public bool Equals(SquadronStoresTable? other)
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
        /// Default Constructor for the <see cref="SquadronStoresTable"/> object.
        /// </summary>
        public SquadronStoresTable()
        {
            _FileType = GameFileType.DatabaseSSD;
            _StreamType = FileStreamType.XML;
            _IsFileModified = false;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="SquadronStoresTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public SquadronStoresTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors

    }
}
