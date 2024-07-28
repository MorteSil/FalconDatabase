using FalconDatabase.Enums;
using FalconDatabase.Internal;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Components
{
    /// <summary>
    /// A Weapon in the Campaign.
    /// </summary>
    public class WeaponDefinition
    {
        #region Properties
        /// <summary>
        /// Index in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Weapon Class ID.
        /// </summary>
        public short ClassID { get => index; set => index = value; }
        /// <summary>
        /// Amount of Damage this Weapon inflicts.
        /// </summary>
        public ushort Strength { get => strength; set => strength = value; }
        /// <summary>
        /// The Damage Type this Weapon Does.
        /// </summary>
        public DamageDataType DamageType { get => damageType; set => damageType = value; }
        /// <summary>
        /// Effective Range.
        /// </summary>
        public float Range { get => range; set => range = value; }
        /// <summary>
        /// Weapon Flags.
        /// </summary>
        public ushort Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Weapon Name.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Hit Chance of Weapon against Targets by Movement Type.
        /// </summary>
        public MovementTypes HitChance { get => hitChance; set => hitChance = value; }
        /// <summary>
        /// Number of projectivels this weapon fires per fire event.
        /// </summary>
        public byte FireRate { get => fireRate; set => fireRate = value; }
        /// <summary>
        /// How rare the Weapon is in Re-Supply calculations.
        /// </summary>
        public byte Rariety { get => rariety; set => rariety = value; }
        /// <summary>
        /// Determines Guidance Type and Characteristics.
        /// </summary>
        public ushort GuidanceFlags { get => guidanceFlags; set => guidanceFlags = value; }
        /// <summary>
        /// If this Weapon is a member of a Collection of other Weapons, such as bomblets.
        /// </summary>
        public byte Collective { get => collective; set => collective = value; }
        /// <summary>
        /// Which Rack Group this Weapon belongs to.
        /// </summary>
        public short RackGroup { get => rackGroup; set => rackGroup = value; }
        /// <summary>
        /// Weapon Weight.
        /// </summary>
        public ushort Weight { get => weight; set => weight = value; }
        /// <summary>
        /// Drag Index of the Weapon.
        /// </summary>
        public short DragIndex { get => dragIndex; set => dragIndex = value; }
        /// <summary>
        /// Effective Blast Radius of the Weapon.
        /// </summary>
        public ushort BlastRadius { get => blastRadius; set => blastRadius = value; }
        /// <summary>
        /// Weapon Radar Type in the Radar Database.
        /// </summary>
        public short RadarType { get => radarType; set => radarType = value; }
        /// <summary>
        /// Index into the SimWeapon Table for Campaign Engine characteristics.
        /// </summary>
        public short SimDataID { get => simDataIdx; set => simDataIdx = value; }
        /// <summary>
        /// Maximum Operating Altitude.
        /// </summary>
        public short MaxAltitude { get => maxAlt; set => maxAlt = value; }
        /// <summary>
        /// Minimum Operating Altitude.
        /// </summary>
        public short MinAltitude { get => minAlt; set => minAlt = value; }
        /// <summary>
        /// How long the Projective stays alive when fired.
        /// </summary>
        public short BulletTTL { get => bulletTTL; set => bulletTTL = value; }
        /// <summary>
        /// Initial Velocity of the Weapon or Projectile when fired.
        /// </summary>
        public short BulletVelocity { get => bulletVelocity; set => bulletVelocity = value; }
        /// <summary>
        /// Base amount of spread or dispersion when multiple projectiles are fired in a single burst.
        /// </summary>
        public byte BulletDispersion { get => bulletDispersion; set => bulletDispersion = value; }
        /// <summary>
        /// How fast the weapon fires when multiple projectiles are fired in a single burst.
        /// </summary>
        public byte BulletRoundsPerSec { get => bulletRoundsPerSec; set => bulletRoundsPerSec = value; }


        #endregion Properties

        #region Fields
        private int iD = 0;
        private short index = 0;
        private ushort strength = 0;
        private DamageDataType damageType;
        private float range = 0;
        private ushort flags = 0;
        private string name = "";
        private MovementTypes hitChance = new();
        private byte fireRate = 0;
        private byte rariety = 0;
        private ushort guidanceFlags = 0;
        private byte collective = 0;
        private short rackGroup = 0;
        private ushort weight = 0;
        private short dragIndex = 0;
        private ushort blastRadius = 0;
        private short radarType;
        private short simDataIdx;
        private short maxAlt = 0;
        private short minAlt = 0;
        private short bulletTTL = 0;
        private short bulletVelocity = 0;
        private byte bulletDispersion = 0;
        private byte bulletRoundsPerSec = 0;

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
            sb.AppendLine("ID: " + ID);
            sb.AppendLine("Weapon ID: " + index);
            sb.AppendLine("Strength: " + strength);
            sb.AppendLine("Damage Type: " + damageType.ToString());
            sb.AppendLine("Range: " + range);
            sb.AppendLine("Flags: " + flags);
            sb.AppendLine("Name: " + name);
            sb.AppendLine("Hit Chance by Enemy Movement Type: ");
            sb.Append(hitChance.ToString());
            sb.AppendLine("Projectiles per Burst: " + fireRate);
            sb.AppendLine("Rarety: " + rariety);
            sb.AppendLine("Guidance Flags: " + guidanceFlags);
            sb.AppendLine("Member of Collective: " + collective);
            sb.AppendLine("Rack Group: " + rackGroup);
            sb.AppendLine("Weight: " + weight);
            sb.AppendLine("Drag Index: " + dragIndex);
            sb.AppendLine("Blast Radius: " + blastRadius);
            sb.AppendLine("Radar Type: " + radarType);
            sb.AppendLine("Sim Weapon Definition ID: " + simDataIdx);
            sb.AppendLine("Max Altitude: " + maxAlt);
            sb.AppendLine("Min Altitude: " + minAlt);
            sb.AppendLine("Bullet Time to Live (TTL): " + bulletTTL);
            sb.AppendLine("Bullet Velocity: " + bulletVelocity);
            sb.AppendLine("Bullet Dispersion: " + bulletDispersion);
            sb.AppendLine("Bullet Rounds per Second: " + bulletRoundsPerSec);

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="WeaponDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\WCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["CtIdx"] = ClassID;
            row["Strength"] = Strength;
            row["DamageType"] = (byte)DamageType;
            row["Range"] = Range;
            row["Flags"] = Flags;
            row["Name"] = Name;

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

            row["FireRate"] = FireRate;
            row["Rariety"] = Rariety;
            row["Guidance"] = GuidanceFlags;
            row["Collective"] = Collective;
            row["Rackgroup"] = RackGroup;
            row["Weight"] = Weight;
            row["Drag"] = DragIndex;
            row["BlastRadius"] = BlastRadius;
            row["RadarIdx"] = RadarType;
            row["SimWeaponDataIdx"] = SimDataID;
            row["MaxAlt"] = MaxAltitude;
            row["MinAlt"] = MinAltitude;
            row["BulletTTL"] = BulletTTL;
            row["BulletVelocity"] = BulletVelocity;
            row["BulletDispersion"] = BulletDispersion;
            row["BulletRoundsPerSec"] = BulletRoundsPerSec;


            return row;
        }
        /// <summary>
        /// Generates a Hash Code for the Object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(index);
            hash.Add(strength);
            hash.Add(damageType);
            hash.Add(range);
            hash.Add(flags);
            hash.Add(name);
            hash.Add(hitChance);
            hash.Add(fireRate);
            hash.Add(rariety);
            hash.Add(guidanceFlags);
            hash.Add(Collective);
            hash.Add(RackGroup);
            hash.Add(weight);
            hash.Add(dragIndex);
            hash.Add(blastRadius);
            hash.Add(radarType);
            hash.Add(simDataIdx);
            hash.Add(maxAlt);
            hash.Add(minAlt);
            hash.Add(bulletTTL);
            hash.Add(bulletVelocity);
            hash.Add(bulletDispersion);
            hash.Add(bulletRoundsPerSec);

            return hash.ToHashCode();
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="WeaponDefinition"/> object.
        /// </summary>
        public WeaponDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="WeaponDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public WeaponDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\WCD.xsd");
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
                Strength = (ushort)row["Strength"];
                DamageType = (DamageDataType)(byte)row["DamageType"];
                Range = (float)row["Range"];
                Flags = (ushort)row["Flags"];
                Name = (string)row["Name"];

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

                FireRate = (byte)row["FireRate"];
                Rariety = (byte)row["Rariety"];
                GuidanceFlags = (ushort)row["Guidance"];
                Collective = (byte)row["Collective"];
                RackGroup = (short)row["Rackgroup"];
                Weight = (ushort)row["Weight"];
                DragIndex = (short)row["Drag"];
                BlastRadius = (ushort)row["BlastRadius"];
                RadarType = (short)row["RadarIdx"];
                SimDataID = (short)row["SimWeaponDataIdx"];
                MaxAltitude = (short)row["MaxAlt"];
                MinAltitude = (short)row["MinAlt"];
                BulletTTL = (short)row["BulletTTL"];
                BulletVelocity = (short)row["BulletVelocity"];
                BulletDispersion = (byte)row["BulletDispersion"];
                BulletRoundsPerSec = (byte)row["BulletRoundsPerSec"];

            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a WCD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
