using FalconDatabase.Enums;
using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Xml;

namespace FalconDatabase.Files
{
    /// <summary>
    /// The Unit Database contained in the FALCON4_UCD.xml File.
    /// </summary>
    public class UnitTable : GameFile, IEquatable<UnitTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="UnitDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<UnitDefinition> UnitDefinitions
        {
            get
            {
                Collection<UnitDefinition> output = new();
                foreach (DataRow row in dbTable.Rows)
                    output.Add(ToUnitDefinition(row));

                return output;
            }
        }
        /// <summary>
        /// Unit Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable Units { get => dbTable; set => dbTable = value; }
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
        private static UnitDefinition ToUnitDefinition(DataRow row)
        {
            try
            {
                int index = 0;

                UnitDefinition output = new()
                {
                    ID = short.Parse((string)row[index++]),
                    Flags = ushort.Parse((string)row[index++]),
                    Name = (string)row[index++],
                    MovementType = (MoveType)int.Parse((string)row[index++]),
                    MovementSpeed = short.Parse((string)row[index++]),
                    MaxRange = short.Parse((string)row[index++]),
                    Fuel = int.Parse((string)row[index++]),
                    Rate = short.Parse((string)row[index++]),
                    PtDataIndex = short.Parse((string)row[index++]),
                    Role = byte.Parse((string)row[index++]),
                    HitChance =
                    [
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        ],
                    Strength =
                    [
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        ],
                    Range =
                    [
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        ],
                    Detection =
                    [
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++]),
                        ],
                    DamageMod =
                    [
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        ],
                    RadarVehicle = short.Parse((string)row[index++]),
                    SquadronStoresID = short.Parse((string)row[index++]),
                    IconIndex = short.Parse((string)row[index++])
                };

                //Num Column
                index++;
                for (int i = 0; i < 16; i++)
                {

                    output.NumElements.Add(i, int.Parse((string)row[index++]));

                }
                for (int i = 0; i < 16; i++)
                {

                    output.VehicleType.Add(i, short.Parse((string)row[index++]));

                }
                for (int i = 0; i < 16; i++)
                {
                    output.ElementFlags.Add(i, ushort.Parse((string)row[index++]));
                }

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
                table.Tables[0].Columns.Add("ElementCountDictionary", typeof(Dictionary<int, int>));
                table.Tables[0].Columns.Add("VehicleTypeDictionary", typeof(Dictionary<int, short>));
                table.Tables[0].Columns.Add("ElementFlagsDictionary", typeof(Dictionary<int, ushort>));

                for (int i = 0; i < table.Tables[0].Rows.Count; i++)
                {
                    Dictionary<int, int> countValues = new Dictionary<int, int>();
                    Dictionary<int, short> typeValues = new Dictionary<int, short>();
                    Dictionary<int, ushort> flagValues = new Dictionary<int, ushort>();
                    DataRow row = table.Tables[0].Rows[i];
                    for (int j = 0; j < 16; j++)
                    {
                        countValues.Add(j, 0);
                        typeValues.Add(j, 0);
                        flagValues.Add(j, 0);
                        if (table.Tables[0].Columns.Contains("ElementCount_" + j) && row["ElementCount_" + j] != DBNull.Value)
                        {
                            int key = j;
                            int val = int.Parse((string)row["ElementCount_" + j]);
                            countValues[j] = val;
                        }

                        if (table.Tables[0].Columns.Contains("VehicleCtIdx_" + j) && row["VehicleCtIdx_" + j] != DBNull.Value)
                        {
                            int key = j;
                            short val = short.Parse((string)row["VehicleCtIdx_" + j]);
                            typeValues[j] = val;
                        }

                        if (table.Tables[0].Columns.Contains("ElementFlags_" + j) && row["ElementFlags_" + j] != DBNull.Value)
                        {
                            int key = j;
                            ushort val = ushort.Parse((string)row["ElementFlags_" + j]);
                            flagValues[j] = val;
                        }
                    }
                    row["ElementCountDictionary"] = countValues;
                    row["VehicleTypeDictionary"] = typeValues;
                    row["ElementFlagsDictionary"] = flagValues;
                }
                for (int i = 0; i < 16; i++)
                {
                    if (table.Tables[0].Columns.Contains("ElementCount_" + i))
                        table.Tables[0].Columns.Remove("ElementCount_" + i);
                    else if (table.Tables[0].Columns.Contains("VehicleCtIdx_" + i))
                        table.Tables[0].Columns.Remove("VehicleCtIdx_" + i);
                    else if (table.Tables[0].Columns.Contains("ElementFlags_" + i))
                        table.Tables[0].Columns.Remove("ElementFlags_" + i);
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
            UnitDefinition[] units = UnitDefinitions.ToArray();
            using MemoryStream stream = new MemoryStream();
            try
            {
                XmlWriter writer = XmlWriter.Create(stream);
                writer.WriteStartDocument();
                writer.WriteStartElement("UCDRecords");
                for (int i = 0; i < units.Length; i++)
                {
                    writer.WriteStartElement("UCD");
                    writer.WriteAttributeString("Num", i.ToString());
                    {
                        writer.WriteStartElement("CtIdx");
                        writer.WriteString(units[i].ID.ToString());
                        writer.WriteEndElement();
                        for (int j = 0; j < units[i].NumElements.Count; j++)
                        {
                            if (units[i].NumElements[j] > 0)
                            {
                                writer.WriteStartElement("ElementCount_" + j.ToString());
                                writer.WriteString(units[i].NumElements[j].ToString());
                                writer.WriteEndElement();
                            }
                        }

                        for (int j = 0; j < units[i].VehicleType.Count; j++)
                        {
                            if (units[i].VehicleType[j] > 0)
                            {
                                writer.WriteStartElement("VehicleCtIdx_" + j.ToString());
                                writer.WriteString(units[i].VehicleType[j].ToString());
                                writer.WriteEndElement();
                            }
                        }

                        for (int j = 0; j < units[i].ElementFlags.Count; j++)
                        {
                            if (units[i].ElementFlags[j] > 0)
                            {
                                writer.WriteStartElement("ElementFlags_" + j.ToString());
                                writer.WriteString(units[i].ElementFlags[j].ToString());
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteStartElement("Flags");
                        writer.WriteString(units[i].Flags.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Name");
                        writer.WriteString(units[i].Name);
                        writer.WriteEndElement();
                        writer.WriteStartElement("MoveType");
                        writer.WriteString(units[i].MovementType.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("MoveSpeed");
                        writer.WriteString(units[i].MovementSpeed.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("MaxRange");
                        writer.WriteString(units[i].Range.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Fuel");
                        writer.WriteString(units[i].Fuel.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("FuelRate");
                        writer.WriteString(units[i].Rate.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("PtDataIdx");
                        writer.WriteString(units[i].PtDataIndex.ToString());
                        writer.WriteEndElement();
                        for (int j = 0; j < units[i].Scores.Count; j++)
                        {
                            if (units[i].Scores[j] > 0)
                            {
                                writer.WriteStartElement("RoleScore_" + j.ToString());
                                writer.WriteString(units[i].Scores[j].ToString());
                                writer.WriteEndElement();
                            }
                        }
                        writer.WriteStartElement("MainRole");
                        writer.WriteString(units[i].Role.ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Hit_NoMove");
                        writer.WriteString(units[i].HitChance[0].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_Foot");
                        writer.WriteString(units[i].HitChance[1].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_Wheeled");
                        writer.WriteString(units[i].HitChance[2].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_Tracked");
                        writer.WriteString(units[i].HitChance[3].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_LowAir");
                        writer.WriteString(units[i].HitChance[4].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_Air");
                        writer.WriteString(units[i].HitChance[5].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_Naval");
                        writer.WriteString(units[i].HitChance[6].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Hit_Rail");
                        writer.WriteString(units[i].HitChance[7].ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Str_NoMove");
                        writer.WriteString(units[i].Strength[0].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_Foot");
                        writer.WriteString(units[i].Strength[1].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_Wheeled");
                        writer.WriteString(units[i].Strength[2].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_Tracked");
                        writer.WriteString(units[i].Strength[3].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_LowAir");
                        writer.WriteString(units[i].Strength[4].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_Air");
                        writer.WriteString(units[i].Strength[5].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_Naval");
                        writer.WriteString(units[i].Strength[6].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Str_Rail");
                        writer.WriteString(units[i].Strength[7].ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Rng_NoMove");
                        writer.WriteString(units[i].Range[0].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_Foot");
                        writer.WriteString(units[i].Range[1].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_Wheeled");
                        writer.WriteString(units[i].Range[2].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_Tracked");
                        writer.WriteString(units[i].Range[3].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_LowAir");
                        writer.WriteString(units[i].Range[4].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_Air");
                        writer.WriteString(units[i].Range[5].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_Naval");
                        writer.WriteString(units[i].Range[6].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Rng_Rail");
                        writer.WriteString(units[i].Range[7].ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Det_NoMove");
                        writer.WriteString(units[i].DamageMod[0].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_Foot");
                        writer.WriteString(units[i].DamageMod[1].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_Wheeled");
                        writer.WriteString(units[i].DamageMod[2].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_Tracked");
                        writer.WriteString(units[i].DamageMod[3].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_LowAir");
                        writer.WriteString(units[i].DamageMod[4].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_Air");
                        writer.WriteString(units[i].DamageMod[5].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_Naval");
                        writer.WriteString(units[i].DamageMod[6].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Det_Rail");
                        writer.WriteString(units[i].DamageMod[7].ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("Dam_None");
                        writer.WriteString(units[i].DamageMod[0].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Penetration");
                        writer.WriteString(units[i].DamageMod[1].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_HighExplosive");
                        writer.WriteString(units[i].DamageMod[2].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Heave");
                        writer.WriteString(units[i].DamageMod[3].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Incendiary");
                        writer.WriteString(units[i].DamageMod[4].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Proximity");
                        writer.WriteString(units[i].DamageMod[5].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Kinetic");
                        writer.WriteString(units[i].DamageMod[6].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Hydrostatic");
                        writer.WriteString(units[i].DamageMod[7].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Chemical");
                        writer.WriteString(units[i].DamageMod[8].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Nuclear");
                        writer.WriteString(units[i].DamageMod[9].ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Dam_Other");
                        writer.WriteString(units[i].DamageMod[10].ToString());
                        writer.WriteEndElement();

                        writer.WriteStartElement("RadarVehicle");
                        writer.WriteString(units[i].RadarVehicle.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("SquadronStoresIdx");
                        writer.WriteString(units[i].SquadronStoresID.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("UnitIcon");
                        writer.WriteString(units[i].IconIndex.ToString());
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
                sb.AppendLine("***** Unit Table Entry *****");
                sb.Append(ToUnitDefinition(row).ToString());
            }

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            UnitTable? comparator = other as UnitTable;
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
        public bool Equals(UnitTable? other)
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
        /// Default Constructor for the <see cref="UnitTable"/> object.
        /// </summary>
        public UnitTable()
        {
            _FileType = GameFileType.DatabaseUCD;
            _StreamType = FileStreamType.XML;
            _IsFileModified = false;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="UnitTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public UnitTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors

    }
}
