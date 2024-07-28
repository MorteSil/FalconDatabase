using FalconDatabase.Enums;
using FalconDatabase.Internal;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Defines a Feature that can be interacted with in the Campaign.
    /// </summary>
    public class FeatureDefinition
    {
        #region Properties
        /// <summary>
        /// Index of this Feature in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// ID of this Feature.
        /// </summary>
        public short ClassID { get => index; set => index = value; }
        /// <summary>
        /// Time in Hours it takes to repair this item.
        /// </summary>
        public short RepairTime { get => repairTime; set => repairTime = value; }
        /// <summary>
        /// Display Priority used by the Graphics Engine.
        /// </summary>
        public byte Priority { get => priority; set => priority = value; }
        /// <summary>
        /// Feature Flags.
        /// </summary>
        public ushort Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Feature Name.
        /// </summary>
        public string Name { get => string.IsNullOrEmpty(name) ? "" : name; set => name = value; }
        /// <summary>
        /// How much damage the Feature can sustain before being destroyed.
        /// </summary>
        public short HitPoints { get => hitPoints; set => hitPoints = value; }
        /// <summary>
        /// Height of Vehicle Ramp if one exists.
        /// </summary>
        public short RampHeight { get => height; set => height = value; }
        /// <summary>
        /// Angle of Vehicle Ramp if one exists.
        /// </summary>
        public float RampAngle { get => angle; set => angle = value; }
        /// <summary>
        /// Radar Id of an attached Radar Object if one exists.
        /// </summary>
        public RadarType RadarType { get => (RadarType)radarType; set => radarType = (short)value; }
        /// <summary>
        /// Collection of Detection Ranges for each Movement Type.
        /// </summary>
        public MovementTypes Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Collection of Damage Modifiers for each Damage Type.
        /// </summary>
        public DamageTypes DamageModifiers { get => damageMod; set => damageMod = value; }
        #endregion Properties

        #region Fields
        private int iD = 0;
        private short index = 0;
        private short repairTime = 0;
        private byte priority = 0;
        private ushort flags = 0;
        private string name = "";
        private short hitPoints = 0;
        private short height = 0;
        private float angle = 0;
        private short radarType = 0;
        private MovementTypes detection = new();
        private DamageTypes damageMod = new();


        #endregion Fields

        #region Functional Methods
        /// <summary>
        /// <para>Formats the data contained within this object into Readable Text.</para>
        /// <para>Readable Text does not always match the underlying file format and should not be used to save text based files such as .xml, .ini, .lst, or .txtpb files.</para>
        /// <para>Instead, use Write() to format all text or binary data for writing to a file.</para>
        /// </summary>
        /// <returns>A formatted <see cref="string"/> with the Data contained within the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("ID: " + iD);
            sb.AppendLine("Feature ID: " + ClassID);
            sb.AppendLine("Repair Time (hours): " + repairTime);
            sb.AppendLine("Display Priority: " + priority);
            sb.AppendLine("Flags: " + flags);
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Hit Points: " + HitPoints);
            sb.AppendLine("Vehicle Ramp Height: " + height);
            sb.AppendLine("Vehicle Ramp Angle: " + angle);
            sb.AppendLine("Radar Type: " + radarType);
            sb.AppendLine("Detection Ranges by Movement Type: ");
            sb.Append(Detection.ToString());
            sb.AppendLine("Damage Modifiers by Damage Type: ");
            sb.Append(DamageModifiers.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="FeatureDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\FCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["CtIdx"] = ClassID;
            row["RepairTime"] = RepairTime;
            row["DisplayPriority"] = Priority;
            row["Flags"] = Flags;
            row["Name"] = Name;
            row["HitPoints"] = HitPoints;
            row["RampHeight"] = RampHeight;
            row["RampAngle"] = RampAngle;
            row["RadarIdx"] = RadarType;
            {
                row["Det_NoMove"] = Detection.NoMovement;
                row["Det_Foot"] = Detection.Foot;
                row["Det_Wheeled"] = Detection.Wheeled;
                row["Det_Tracked"] = Detection.Tracked;
                row["Det_LowAir"] = Detection.LowAir;
                row["Det_Air"] = Detection.Air;
                row["Det_Naval"] = Detection.Naval;
                row["Det_Rail"] = Detection.Rail;
            }

            {
                row["Dam_None"] = damageMod.NoDamage;
                row["Dam_Penetration"] = damageMod.Penetration;
                row["Dam_HighExplosive"] = damageMod.HighExplosive;
                row["Dam_Heave"] = damageMod.Heave;
                row["Dam_Incendairy"] = damageMod.Incendiary;
                row["Dam_Proximity"] = damageMod.Proximity;
                row["Dam_Kinetic"] = damageMod.Kinetic;
                row["Dam_Hydrostatic"] = damageMod.Hydrostatic;
                row["Dam_Chemical"] = damageMod.Chemical;
                row["Dam_Nuclear"] = damageMod.Nuclear;
                row["Dam_Other"] = damageMod.Other;
            }


            return row;
        }
        /// <summary>
        /// Generates a Hash Code for the Object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            HashCode hash = new ();
            hash.Add(index);
            hash.Add(repairTime);
            hash.Add(priority);
            hash.Add(flags);
            hash.Add(name);
            hash.Add(HitPoints);
            hash.Add(height);
            hash.Add(angle);
            hash.Add(radarType);
            hash.Add(detection);
            hash.Add(damageMod);
            return hash.ToHashCode();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="FeatureDefinition"/> object.
        /// </summary>
        public FeatureDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="FeatureDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public FeatureDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\FCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            try
            {
                // Verify row conforms to Schema
                table.Rows.Add(row.ItemArray);

                // Create Object

                ID = (int)row["Num"];
                ClassID = (short)row["CtIdx"];
                RepairTime = (short)row["RepairTime"];
                Priority = (byte)row["DisplayPriority"];
                Flags = (ushort)row["Flags"];
                Name = (string)row["Name"];
                HitPoints = (short)row["HitPoints"];
                RampHeight = (short)row["RampHeight"];
                RampAngle = (float)row["RampAngle"];
                RadarType = (RadarType)((short)row["RadarIdx"]);
                {
                    Detection.NoMovement = (float)row["Det_NoMove"];
                    Detection.Foot = (float)row["Det_Foot"];
                    Detection.Wheeled = (float)row["Det_Wheeled"];
                    Detection.Tracked = (float)row["Det_Tracked"];
                    Detection.LowAir = (float)row["Det_LowAir"];
                    Detection.Air = (float)row["Det_Air"];
                    Detection.Naval = (float)row["Det_Naval"];
                    Detection.Rail = (float)row["Det_Rail"];
                }

                {
                    damageMod.NoDamage = (byte)row["Dam_None"];
                    damageMod.Penetration = (byte)row["Dam_Penetration"];
                    damageMod.HighExplosive = (byte)row["Dam_HighExplosive"];
                    damageMod.Heave = (byte)row["Dam_Heave"];
                    damageMod.Incendiary = (byte)row["Dam_Incendairy"];
                    damageMod.Proximity = (byte)row["Dam_Proximity"];
                    damageMod.Kinetic = (byte)row["Dam_Kinetic"];
                    damageMod.Hydrostatic = (byte)row["Dam_Hydrostatic"];
                    damageMod.Chemical = (byte)row["Dam_Chemical"];
                    damageMod.Nuclear = (byte)row["Dam_Nuclear"];
                    damageMod.Other = (byte)row["Dam_Other"];
                }

            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a FCD Entry.");
                throw;
            }
        }
        #endregion Constructors     

        #region Subclasses
        /// <summary>
        /// Contents of the Feature Flags.
        /// </summary>
        public struct FeatureFlags
        {
            // TODO: Map this
        }
        #endregion Subclasses
    }
}
