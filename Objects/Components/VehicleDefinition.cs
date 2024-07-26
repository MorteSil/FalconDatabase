using FalconDatabase.Internal;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A vehicle in the Campaign.
    /// </summary>
    public class VehicleDefinition
    {
        #region Properties
        /// <summary>
        /// Index in the Table
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Vehicle ID in the Database.
        /// </summary>
        public short ClassID { get => index; set => index = value; }
        /// <summary>
        /// Damage the Vehicle can withstand.
        /// </summary>
        public short HitPoints { get => hitPoints; set => hitPoints = value; }
        /// <summary>
        /// Vehicle Flags.
        /// </summary>
        public uint Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Vehicle Name.
        /// </summary>
        public string Name { get => string.IsNullOrEmpty(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Value displayed in the FCR when NCTR is evaluated.
        /// </summary>
        public string NCTR { get => string.IsNullOrEmpty(nctr) ? " " : name; set => nctr = value; }
        /// <summary>
        /// Radar Cross Section calculated as log2( 1 + RCS relative to an F16 ).
        /// </summary>
        public float RCSFactor { get => rcsFactor; set => rcsFactor = value; }
        /// <summary>
        /// Maximum Weight the Vehicle can operate with.
        /// </summary>
        public int MaxWeight { get => maxWt; set => maxWt = value; }
        /// <summary>
        /// Vehicle Empty or Dry Weight.
        /// </summary>
        public int EmptyWeightt { get => emptyWt; set => emptyWt = value; }
        /// <summary>
        /// Amount of Fuel the Vehicle can carry.
        /// </summary>
        public int FuelWeight { get => fuelWt; set => fuelWt = value; }
        /// <summary>
        /// Rate the Vehicle burns fuel.
        /// </summary>
        public short FuelBurnRate { get => fuelEcon; set => fuelEcon = value; }
        /// <summary>
        /// Index into the Engine Sound Table.
        /// </summary>
        public short EngineSoundID { get => engineSound; set => engineSound = value; }
        /// <summary>
        /// Minimum Operating Altitude.
        /// </summary>
        public short MinAltitude { get => lowAlt; set => lowAlt = value; }
        /// <summary>
        /// Maximum Operating Altituide.
        /// </summary>
        public short MaxAltitude { get { return maxAlt; } set { maxAlt = value; } }
        /// <summary>
        /// Standard Operating Altitude.
        /// </summary>
        public short CruiseAlttitude { get => cruiseAlt; set => cruiseAlt = value; }
        /// <summary>
        /// Maximum Speed the Vehicle can operate at.
        /// </summary>
        public short MaxSpeed { get => maxSpeed; set => maxSpeed = value; }
        /// <summary>
        /// Radar Type from the Radar Database installed on the Vehicle.
        /// </summary>
        public short RadarType { get => radarType; set => radarType = value; }
        /// <summary>
        /// Number of Pilots assigned to the Vehicle. Used when displaying Ejection Events.
        /// </summary>
        public byte NumberOfPilots { get => numberOfPilots; set => numberOfPilots = value; }
        /// <summary>
        /// <para>Visbility Flags used by the Graphics Engine for Rack Visibility.</para>
        /// <para>//0x01 means hardpoint 0 is visible, 0x02 -> hdpt 1, etc</para>
        /// </summary>
        public ushort VisibleFlags { get => visibleFlags; set => visibleFlags = value; }
        /// <summary>
        /// Index into the Callsign List for this Vehicle.
        /// </summary>
        public byte CallsignIndex { get => callsignIndex; set => callsignIndex = value; }
        /// <summary>
        /// Number of Callsign Numbers this Vehicle requires.
        /// </summary>
        public byte CallsignSlots { get => callsignSlots; set => callsignSlots = value; }
        /// <summary>
        /// Hit Chance of Vehicle against Targets by Movement Type.
        /// </summary>
        public MovementTypes HitChance { get => hitChance; set => hitChance = value; }
        /// <summary>
        /// Strength against Targets by Movement Type.
        /// </summary>
        public MovementTypes Strength { get => strength; set => strength = value; }
        /// <summary>
        /// Effective Range against Targets by Movement Type.
        /// </summary>
        public MovementTypes Range { get => range; set => range = value; }
        /// <summary>
        /// Detection Range against Targets by Movement Type.
        /// </summary>
        public MovementTypes Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Damage Modifier Against Targets by Movement Type.
        /// </summary>
        public DamageTypes DamageModifier { get => damageMod; set => damageMod = value; }
        /// <summary>
        /// Weapons attached to the Vehicle Hardpoints
        /// </summary>
        public Collection<(short WpnID, byte WpnCount)> Weapons 
        { 
            get => weapons; 
            set
            {
                while (value.Count > 16) value.RemoveAt(16);
                weapons = value;
            }
        }        
        /// <summary>
        /// <para>Determines which Hardpoints require Racks on the Vehicle.</para>
        /// <para>//0x01 means hardpoint 0 needs a rack, 0x02 -> hdpt 1, etc</para>
        /// </summary>
        public ushort RackFlags { get => rackFalgs; set => rackFalgs = value; }       
        /// <summary>
        /// Objective ID of Carrier Target Objectives.
        /// </summary>
        public short CarrierObjectiveID { get => maxAlt; set => maxAlt = value; }   // CTIndex of a carriers objective data 
        /// <summary>
        /// If the Vehicle is a Vertical Launch System (VLS).
        /// </summary>
        public ushort IsVerticalLaunchingSystem { get => rackFalgs; set => rackFalgs = value; }  //0x01 means this slot is a VLS type
        
        #endregion Properties

        #region Fields
        private int iD = 0;
        private short index = 0;
        private short hitPoints = 0;
        private uint flags = 0;
        private string name = "";            //Limited to 15 still?
        private string nctr = "";            //Limited to 5 still?
        private float rcsFactor = 0;
        private int maxWt = 0;
        private int emptyWt = 0;
        private int fuelWt = 0;
        private short fuelEcon = 0;
        private short engineSound = 0;
        private short maxAlt = 0;
        private short lowAlt = 0;
        private short cruiseAlt = 0;
        private short maxSpeed = 0;
        private short radarType = 0;
        private byte numberOfPilots = 0;
        private ushort rackFalgs = 0;
        private ushort visibleFlags = 0;
        private byte callsignIndex = 0;
        private byte callsignSlots = 0;
        private MovementTypes hitChance = new();
        private MovementTypes strength = new();
        private MovementTypes range = new();
        private MovementTypes detection = new();
        private Collection<(short WpnID, byte WpnCount)> weapons = [];
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
            StringBuilder sb = new ();
            sb.AppendLine("Vehicle ID:" + index);
            sb.AppendLine("Vehicle Hit Points: " + hitPoints);
            sb.AppendLine("Vehicle Flags: " + flags);
            sb.AppendLine("Name: " + name);
            sb.AppendLine("NCTR Display:" + nctr);
            sb.AppendLine("Radar Cross Signature: " + rcsFactor);
            sb.AppendLine("Max Operating Weight: " + maxWt);
            sb.AppendLine("Empty Weight: " + emptyWt);
            sb.AppendLine("Fuel Load: " + fuelWt);
            sb.AppendLine("Fuel Burn Rate: " + fuelEcon);
            sb.AppendLine("Engine Sound ID: " + engineSound);
            sb.AppendLine("Min Operating Altitude: " + lowAlt);
            sb.AppendLine("Max Operating Altitude: " + MaxAltitude);
            sb.AppendLine("Cruise Altitude: " + cruiseAlt);
            sb.AppendLine("Max Speed: " + MaxSpeed);
            sb.AppendLine("Radar ID: " + radarType);
            sb.AppendLine("Crew Members: " + numberOfPilots);
            sb.AppendLine("Rack Flags: " + RackFlags);
            sb.AppendLine("Rack Visibility Flags: " + visibleFlags);
            sb.AppendLine("Callsign ID: " + callsignIndex);
            sb.AppendLine("Callsign Slots: " + callsignSlots);
            sb.AppendLine("***** Hit Chances ***** ");
            sb.Append(hitChance.ToString());
            sb.AppendLine("***** Strength vs *****");
            sb.Append(strength.ToString());
            sb.AppendLine("***** Range vs *****");
            sb.Append(range.ToString());
            sb.AppendLine("***** Detection vs *****");
            sb.Append(detection.ToString());            
            sb.AppendLine("***** Damage Modifiers by Damage Type *****");
            sb.Append(DamageModifier.ToString());
            sb.AppendLine("Weapon List:");
            for (int i =0;i<Weapons.Count;i++)
            {
                if (Weapons[i].WpnCount != 0)
                    sb.AppendLine("Weapon " + Weapons[i].WpnID + ": x" + Weapons[i].WpnCount);
            }            
            sb.AppendLine("Rack Flags: " +RackFlags);
            sb.AppendLine("Carrier Objective ID:" + CarrierObjectiveID);
            sb.AppendLine("Is Vertical Launch System: " + IsVerticalLaunchingSystem);


            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="AircraftDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\VCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["CtIdx"] = ClassID;
            row["HitPoints"] = HitPoints;
            row["Flags"] = Flags;
            row["Name"] = Name;
            row["NCTR"] = NCTR;
            row["RadarCs"] = RCSFactor;
            row["MaxWeight"] = MaxWeight;
            row["EmptyWeight"] = EmptyWeightt;
            row["FuelWeight"] = FuelWeight;
            row["FuelRate"] = FuelBurnRate;
            row["EngineSound"] = EngineSoundID;
            row["MaxAlt"] = MaxAltitude;
            row["MinAlt"] = MinAltitude;
            row["CruiseAlt"] = CruiseAlttitude;
            row["MaxSpeed"] = MaxSpeed;
            row["RadarIdx"] = RadarType;
            row["NumberOfCrew"] = NumberOfPilots;
            row["RackFlags"] = RackFlags;
            row["VisibleFlags"] = VisibleFlags;
            row["CallsignIdx"] = CallsignIndex;
            row["CallsignSlots"] = CallsignSlots;

            {
                row["Hit_NoMove"] = (byte)HitChance.NoMovement;
                row["Hit_Foot"] = (byte)HitChance.Foot;
                row["Hit_Wheeled"] = (byte)HitChance.Wheeled;
                row["Hit_Tracked"] = (byte)HitChance.Tracked;
                row["Hit_LowAir"] = (byte)HitChance.LowAir;
                row["Hit_Air"] = (byte)HitChance.Air;
                row["Hit_Naval"] = (byte)HitChance.Naval;
                row["Hit_Rail"] = (byte)HitChance.Rail;
            }

            {
                row["Str_NoMove"] = (byte)Strength.NoMovement;
                row["Str_Foot"] = (byte)Strength.Foot;
                row["Str_Wheeled"] = (byte)Strength.Wheeled;
                row["Str_Tracked"] = (byte)Strength.Tracked;
                row["Str_LowAir"] = (byte)Strength.LowAir;
                row["Str_Air"] = (byte)Strength.Air;
                row["Str_Naval"] = (byte)Strength.Naval;
                row["Str_Rail"] = (byte)Strength.Rail;
            }

            {
                row["Rng_NoMove"] = (byte)Range.NoMovement;
                row["Rng_Foot"] = (byte)Range.Foot;
                row["Rng_Wheeled"] = (byte)Range.Wheeled;
                row["Rng_Tracked"] = (byte)Range.Tracked;
                row["Rng_LowAir"] = (byte)Range.LowAir;
                row["Rng_Air"] = (byte)Range.Air;
                row["Rng_Naval"] = (byte)Range.Naval;
                row["Rng_Rail"] = (byte)Range.Rail;
            }

            {
                row["Det_NoMove"] = (float)Detection.NoMovement;
                row["Det_Foot"] = (float)Detection.Foot;
                row["Det_Wheeled"] = (float)Detection.Wheeled;
                row["Det_Tracked"] = (float)Detection.Tracked;
                row["Det_LowAir"] = (float)Detection.LowAir;
                row["Det_Air"] = (float)Detection.Air;
                row["Det_Naval"] = (float)Detection.Naval;
                row["Det_Rail"] = (float)Detection.Rail;
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

            for (int i=0; i<16;i++)
            {
                if (weapons[i].WpnID != -1)
                {
                    row["WpnOrHpIdx_" + i] = weapons[i].WpnID;
                    row["WpnCount_" + i] = weapons[i].WpnCount;
                }
                else
                {
                    row["WpnOrHpIdx_" + i] = DBNull.Value;
                    row["WpnCount_" + i] = DBNull.Value;
                }
            }

            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor the <see cref="VehicleDefinition"/> object.
        /// </summary>
        public VehicleDefinition() 
        {
            for (int i = 0; i < 16; i++)
                weapons.Add((-1, 0));
        }
        /// <summary>
        /// Initializes an instance of the <see cref="VehicleDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public VehicleDefinition(DataRow row)
            :this()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\VCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new DataSet();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            try
            {
                // Verify row conforms to Schema
                table.Rows.Add(row.ItemArray);

                // Create Object
                ID = (int)row["Num"];
                ClassID = (short)row["CtIdx"];
                HitPoints = (short)row["HitPoints"];
                Flags = (uint)row["Flags"];
                Name = (string)row["Name"];
                NCTR = (string)row["NCTR"];
                RCSFactor = (float)row["RadarCs"];
                MaxWeight = (int)row["MaxWeight"];
                EmptyWeightt = (int)row["EmptyWeight"];
                FuelWeight = (int)row["FuelWeight"];
                FuelBurnRate = (short)row["FuelRate"];
                EngineSoundID = (short)row["EngineSound"];
                MaxAltitude = (short)row["MaxAlt"];
                MinAltitude = (short)row["MinAlt"];
                CruiseAlttitude = (short)row["CruiseAlt"];
                MaxSpeed = (short)row["MaxSpeed"];
                RadarType = (short)row["RadarIdx"];
                NumberOfPilots = (byte)row["NumberOfCrew"];
                RackFlags = (ushort)row["RackFlags"];
                VisibleFlags = (ushort)row["VisibleFlags"];
                CallsignIndex = (byte)row["CallsignIdx"];
                CallsignSlots = (byte)row["CallsignSlots"];

                {
                    HitChance.NoMovement = (byte)row["Hit_NoMove"];
                    HitChance.Foot = (byte)row["Hit_Foot"];
                    HitChance.Wheeled = (byte)row["Hit_Wheeled"];
                    HitChance.Tracked = (byte)row["Hit_Tracked"];
                    HitChance.LowAir = (byte)row["Hit_LowAir"];
                    HitChance.Air = (byte)row["Hit_Air"];
                    HitChance.Naval = (byte)row["Hit_Naval"];
                    HitChance.Rail = (byte)row["Hit_Rail"];
                }

                {
                    Strength.NoMovement = (byte)row["Str_NoMove"];
                    Strength.Foot = (byte)row["Str_Foot"];
                    Strength.Wheeled = (byte)row["Str_Wheeled"];
                    Strength.Tracked = (byte)row["Str_Tracked"];
                    Strength.LowAir = (byte)row["Str_LowAir"];
                    Strength.Air = (byte)row["Str_Air"];
                    Strength.Naval = (byte)row["Str_Naval"];
                    Strength.Rail = (byte)row["Str_Rail"];
                }

                {
                    Range.NoMovement = (byte)row["Rng_NoMove"];
                    Range.Foot = (byte)row["Rng_Foot"];
                    Range.Wheeled = (byte)row["Rng_Wheeled"];
                    Range.Tracked = (byte)row["Rng_Tracked"];
                    Range.LowAir = (byte)row["Rng_LowAir"];
                    Range.Air = (byte)row["Rng_Air"];
                    Range.Naval = (byte)row["Rng_Naval"];
                    Range.Rail = (byte)row["Rng_Rail"];
                }

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


                for (int i = 0; i < 16; i++)
                {
                    if (row["WpnOrHpIdx_" + i] != DBNull.Value)
                    {
                        weapons[i] = ((short)row["WpnOrHpIdx_" + i], (byte)row["WpnCount_" + i]);
                    }

                }
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a VCD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
