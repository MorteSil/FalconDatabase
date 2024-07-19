using System.Collections.ObjectModel;
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
        /// Vehicle ID in the Database.
        /// </summary>
        public short ID { get => index; set => index = value; }
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
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Value displayed in the FCR when NCTR is evaluated.
        /// </summary>
        public string NCTR { get => nctr; set => nctr = value; }
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
        public short MaxAltitude { get { return Union1; } set { Union1 = value; } }
        /// <summary>
        /// Standard Operating Altitude.
        /// </summary>
        public short CruiseAlt { get => cruiseAlt; set => cruiseAlt = value; }
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
        public short NumberOfPilots { get => numberOfPilots; set => numberOfPilots = value; }
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
        public Collection<byte> HitChance { get => hitChance; set => hitChance = value; }
        /// <summary>
        /// Strength against Targets by Movement Type.
        /// </summary>
        public Collection<byte> Strength { get => strength; set => strength = value; }
        /// <summary>
        /// Effective Range against Targets by Movement Type.
        /// </summary>
        public Collection<byte> Range { get => range; set => range = value; }
        /// <summary>
        /// Detection Range against Targets by Movement Type.
        /// </summary>
        public Collection<byte> Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Damage Modifier Against Targets by Movement Type.
        /// </summary>
        public Collection<byte> DamageMod { get => damageMod; set => damageMod = value; }
        /// <summary>
        /// Collection of Weapons Installed on the Vehicle.
        /// </summary>
        public Dictionary<int, short> WeaponList { get => weapon; set => weapon = value; }
        /// <summary>
        /// Maximum Ammo for each Weapon Installed on the Vehicle.
        /// </summary>
        public Dictionary<int, byte> AmmunitionCount { get => weapons; set => weapons = value; }
        /// <summary>
        /// Signature of the Vehicle when observed from a Visual Sensor Type.
        /// </summary>
        public byte VisualSignature { get => visSignature; set => visSignature = value; }
        /// <summary>
        /// Signature of Vehicle when observed from an IR Sensor Type.
        /// </summary>
        public byte IRSignature { get => irSignature; set => irSignature = value; }
        /// <summary>
        /// <para>Determines which Hardpoints require Racks on the Vehicle.</para>
        /// <para>//0x01 means hardpoint 0 needs a rack, 0x02 -> hdpt 1, etc</para>
        /// </summary>
        public ushort RackFlags { get { return Union2; } set { Union2 = value; } }
        /// <summary>
        /// Determines if the Gun installed on the Vehicle can engage Air Targets.
        /// </summary>
        public ushort GunIsAACapable { get { return Union2; } set { Union2 = value; } }				//0x01 means gun on this HP can shoot against airborne targets
        /// <summary>
        /// Objective ID of Carrier Target Objectives.
        /// </summary>
        public short CarrierObjectiveCTIndex { get { return Union1; } set { Union1 = value; } }   // CTIndex of a carriers objective data 
        /// <summary>
        /// If the Vehicle is a Vertical Launch System (VLS).
        /// </summary>
        public ushort IsVerticalLaunchingSystem { get { return Union2; } set { Union2 = value; } }  //0x01 means this slot is a VLS type



        #endregion Properties

        #region Fields
        private short index;
        private short hitPoints;
        private uint flags;
        private string name = "";            //Limited to 15 still?
        private string nctr = "";            //Limited to 5 still?
        private float rcsFactor;
        private int maxWt;
        private int emptyWt;
        private int fuelWt;
        private short fuelEcon;
        private short engineSound;
        internal short Union1;
        private short lowAlt;
        private short cruiseAlt;
        private short maxSpeed;
        private short radarType;
        private short numberOfPilots;
        internal ushort Union2;
        private ushort visibleFlags;
        private byte callsignIndex;
        private byte callsignSlots;
        private Collection<byte> hitChance = [];
        private Collection<byte> strength = [];
        private Collection<byte> range = [];
        private Collection<byte> detection = [];
        private Dictionary<int, short> weapon = [];
        private Dictionary<int, byte> weapons = [];
        private Collection<byte> damageMod = [];
        private byte visSignature;
        private byte irSignature;
        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
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
            sb.AppendLine("Statistics by Enemy Movement Type: ");
            for (int i = 0; i < HitChance.Count; i++)
            {
                sb.AppendLine("   Movement Type " + i + ":");
                sb.AppendLine("     Hit Chance: " + HitChance[i]);
                sb.AppendLine("     Strength: " + Strength[i]);
                sb.AppendLine("     Range: " + Range[i]);
                sb.AppendLine("     Detection: " + Detection[i]);
            }
            sb.AppendLine("Damage Modifiers by Damage Type: ");
            for (int i = 0; i < DamageMod.Count; i++)
                sb.AppendLine("   " + "Damage Type " + i + ": " + damageMod[i]);


            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor the <see cref="VehicleDefinition"/> object.
        /// </summary>
        public VehicleDefinition() { }
        #endregion Constructors     

    }
}
