using FalconDatabase.Enums;
using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Xml;

namespace FalconDatabase.Files
{
    /// <summary>
    /// Weapon Hardpoint and Rack Component of the Database.
    /// </summary>
    public class WeaponLoadTable : GameFile, IEquatable<WeaponLoadTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="WeaponLoadTable" /> Entries exported from the Database.
        /// </summary>
        public Collection<WeaponLoadDefinition> WeaponLoadDefinitions
        {
            get
            {
                Collection<WeaponLoadDefinition> output = new();
                foreach (DataRow row in dbTable.Rows)
                    output.Add(ToWeaponLoadDefinition(row));

                return output;
            }
        }
        /// <summary>
        /// Weapon Load Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable WeaponLoads { get => dbTable; set => dbTable = value; }
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
        private static WeaponLoadDefinition ToWeaponLoadDefinition(DataRow row)
        {
            try
            {
                WeaponLoadDefinition output = new()
                {
                    Name = (string)row[0],
                    WeaponList = (Collection<Tuple<short, short>>)row[2]

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
                table.Tables[0].Columns.Add("WeaponsTuple", typeof(Collection<Tuple<short, short>>));

                for (int i = 0; i < table.Tables[0].Rows.Count; i++)
                {
                    Collection<Tuple<short, short>> weaponValues = new();
                    DataRow row = table.Tables[0].Rows[i];
                    for (int j = 0; j < 100; j++)
                    {
                        weaponValues.Add(new Tuple<short, short>(0, 0));
                        if (table.Tables[0].Columns.Contains("WpnIdx_" + j) && row["WpnIdx_" + j] != DBNull.Value)
                        {
                            int key = j;
                            short val = short.Parse((string)row["WpnIdx_" + j]);
                            short val2 = short.Parse((string)row["WpnCount_" + j]);
                            weaponValues[j] = new Tuple<short, short>(val, val2);
                        }
                    }
                    row["WeaponsTuple"] = weaponValues;
                }
                for (int i = 0; i < 100; i++)
                {
                    if (table.Tables[0].Columns.Contains("WpnIdx_" + i))
                        table.Tables[0].Columns.Remove("WpnIdx_" + i);
                    else if (table.Tables[0].Columns.Contains("WpnCount_" + i))
                        table.Tables[0].Columns.Remove("WpnCount_" + i);
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
            WeaponLoadDefinition[] weapons = WeaponLoadDefinitions.ToArray();
            using MemoryStream stream = new MemoryStream();
            try
            {
                XmlWriter writer = XmlWriter.Create(stream);
                writer.WriteStartDocument();
                writer.WriteStartElement("WLDRecords");
                for (int i = 0; i < weapons.Length; i++)
                {
                    writer.WriteStartElement("WLD");
                    writer.WriteAttributeString("Num", i.ToString());
                    {
                        writer.WriteStartElement("Name");
                        writer.WriteString(weapons[i].Name);
                        writer.WriteEndElement();
                        for (int j = 0; j < weapons[i].WeaponList.Count; j++)
                        {
                            if (weapons[i].WeaponList[j].Item1 > 0)
                            {
                                writer.WriteStartElement("WpnIdx_" + j.ToString());
                                writer.WriteString(weapons[i].WeaponList[j].Item1.ToString());
                                writer.WriteEndElement();
                            }
                        }

                        for (int j = 0; j < weapons[i].WeaponList.Count; j++)
                        {
                            if (weapons[i].WeaponList[j].Item2 > 0)
                            {
                                writer.WriteStartElement("WpnCount_" + j.ToString());
                                writer.WriteString(weapons[i].WeaponList[j].Item2.ToString());
                                writer.WriteEndElement();
                            }
                        }
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
                sb.AppendLine("***** Weapon Table Entry *****");
                sb.Append(ToWeaponLoadDefinition(row).ToString());
            }

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            WeaponLoadTable? comparator = other as WeaponLoadTable;
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
        public bool Equals(WeaponLoadTable? other)
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
        /// Default Constructor for the <see cref="WeaponLoadTable"/> object.
        /// </summary>
        public WeaponLoadTable()
        {
            _FileType = GameFileType.DatabaseWLD;
            _StreamType = FileStreamType.XML;
            _IsFileModified = false;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="WeaponLoadTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public WeaponLoadTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors

    }
}
