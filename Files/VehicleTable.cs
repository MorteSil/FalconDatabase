using FalconDatabase.Enums;
using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Xml;

namespace FalconDatabase.Files
{
    /// <summary>
    /// A Vehicle in the Campaign.
    /// </summary>
    public class VehicleTable : GameFile, IEquatable<VehicleTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="VehicleDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<VehicleDefinition> VehicleDefinitions
        {
            get
            {
                Collection<VehicleDefinition> output = new();
                foreach (DataRow row in dbTable.Rows)
                    output.Add(ToVehicleDefinition(row));

                return output;
            }
        }
        /// <summary>
        /// Vehicle Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable Vehicles { get => dbTable; set => dbTable = value; }
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
        private static VehicleDefinition ToVehicleDefinition(DataRow row)
        {
            try
            {
                int index = 0;
                VehicleDefinition output = new()
                {
                    ID = short.Parse((string)row[index++]),
                    HitPoints = short.Parse((string)row[index++]),
                    Name = (string)row[index++],
                    NCTR = (string)row[index++],
                    RCSFactor = float.Parse((string)row[index++]),
                    MaxWeight = int.Parse((string)row[index++]),
                    FuelWeight = int.Parse((string)row[index++]),
                    FuelBurnRate = short.Parse((string)row[index++]),
                    EngineSoundID = short.Parse((string)row[index++]),
                    MaxAltitude = short.Parse((string)row[index++]),
                    MinAltitude = short.Parse((string)row[index++]),
                    CruiseAlt = short.Parse((string)row[index++]),
                    MaxSpeed = short.Parse((string)row[index++]),
                    RadarType = short.Parse((string)row[index++]),
                    NumberOfPilots = short.Parse((string)row[index++]),
                    RackFlags = ushort.Parse((string)row[index++]),
                    VisibleFlags = ushort.Parse((string)row[index++]),
                    CallsignIndex = byte.Parse((string)row[index++]),
                    CallsignSlots = byte.Parse((string)row[index++]),
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
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
                        byte.Parse((string)row[index++]),
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
                    ]
                };
                index++;
                output.WeaponList = (Dictionary<int, short>)row[index++];
                output.AmmunitionCount = (Dictionary<int, byte>)row[index++];
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
                table.Tables[0].Columns.Add("WeaponDictionary", typeof(Dictionary<int, short>));
                table.Tables[0].Columns.Add("AmmunitionDictionary", typeof(Dictionary<int, byte>));

                for (int i = 0; i < table.Tables[0].Rows.Count; i++)
                {
                    Dictionary<int, short> weaponValues = new Dictionary<int, short>();
                    Dictionary<int, byte> ammunitionValues = new Dictionary<int, byte>();
                    DataRow row = table.Tables[0].Rows[i];
                    for (int j = 0; j < 16; j++)
                    {
                        weaponValues.Add(j, 0);
                        ammunitionValues.Add(j, 0);
                        if (table.Tables[0].Columns.Contains("WpnOrHpIdx_" + j) && row["WpnOrHpIdx_" + j] != DBNull.Value)
                        {
                            int key = j;
                            short val = short.Parse((string)row["WpnOrHpIdx_" + j]);
                            weaponValues[j] = val;
                        }

                        if (table.Tables[0].Columns.Contains("WpnCount_" + j) && row["WpnCount_" + j] != DBNull.Value)
                        {
                            int key = j;
                            byte val = byte.Parse((string)row["WpnCount_" + j]);
                            ammunitionValues[j] = val;
                        }


                    }
                    row["WeaponDictionary"] = weaponValues;
                    row["AmmunitionDictionary"] = ammunitionValues;
                }
                for (int i = 0; i < 16; i++)
                {
                    if (table.Tables[0].Columns.Contains("WpnOrHpIdx_" + i))
                        table.Tables[0].Columns.Remove("WpnOrHpIdx_" + i);
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
            VehicleDefinition[] units = VehicleDefinitions.ToArray();
            using MemoryStream stream = new MemoryStream();
            try
            {
                XmlWriter writer = XmlWriter.Create(stream);
                writer.WriteStartDocument();
                writer.WriteStartElement("VCDRecords");
                for (int i = 0; i < units.Length; i++)
                {
                    writer.WriteStartElement("VCD");
                    writer.WriteAttributeString("Num", i.ToString());
                    {
                        writer.WriteStartElement("CtIdx");
                        writer.WriteString(units[i].ID.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("HitPoints");
                        writer.WriteString(units[i].HitPoints.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Flags");
                        writer.WriteString(units[i].Flags.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("Name");
                        writer.WriteString(units[i].Name.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("NCTR");
                        writer.WriteString(units[i].NCTR.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("RadarCs");
                        writer.WriteString(units[i].RCSFactor.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("MaxWeight");
                        writer.WriteString(units[i].MaxWeight.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("EmptyWeight");
                        writer.WriteString(units[i].EmptyWeightt.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("FuelWeight");
                        writer.WriteString(units[i].FuelWeight.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("FuelRate");
                        writer.WriteString(units[i].FuelBurnRate.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("EngineSound");
                        writer.WriteString(units[i].EngineSoundID.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("MaxAlt");
                        writer.WriteString(units[i].MaxAltitude.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("MinAlt");
                        writer.WriteString(units[i].MinAltitude.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("CruiseAlt");
                        writer.WriteString(units[i].CruiseAlt.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("MaxSpeed");
                        writer.WriteString(units[i].MaxSpeed.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("RadarIdx");
                        writer.WriteString(units[i].RadarType.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("NumberOfCrew");
                        writer.WriteString(units[i].NumberOfPilots.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("RackFlags");
                        writer.WriteString(units[i].RackFlags.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("VisibleFlags");
                        writer.WriteString(units[i].VisibleFlags.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("CallsignIdx");
                        writer.WriteString(units[i].CallsignIndex.ToString());
                        writer.WriteEndElement();
                        writer.WriteStartElement("CallsignSlots");
                        writer.WriteString(units[i].CallsignSlots.ToString());
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

                        for (int j = 0; j < units[i].WeaponList.Count; j++)
                        {
                            if (units[i].WeaponList[j] > 0)
                            {
                                writer.WriteStartElement("WpnOrHpIdx_" + j.ToString());
                                writer.WriteString(units[i].WeaponList[j].ToString());
                                writer.WriteEndElement();
                            }
                        }

                        for (int j = 0; j < units[i].AmmunitionCount.Count; j++)
                        {
                            if (units[i].AmmunitionCount[j] > 0)
                            {
                                writer.WriteStartElement("WpnCount_" + j.ToString());
                                writer.WriteString(units[i].AmmunitionCount[j].ToString());
                                writer.WriteEndElement();
                            }
                        }

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
                sb.AppendLine("***** Vehicle Table Entry *****");
                sb.Append(ToVehicleDefinition(row).ToString());
            }

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            VehicleTable? comparator = other as VehicleTable;
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
        public bool Equals(VehicleTable? other)
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
        /// Default Constructor for the <see cref="VehicleTable"/> object.
        /// </summary>
        public VehicleTable()
        {
            _FileType = GameFileType.DatabaseVCD;
            _StreamType = FileStreamType.XML;
            _IsFileModified = false;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="VehicleTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public VehicleTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors

    }
}
