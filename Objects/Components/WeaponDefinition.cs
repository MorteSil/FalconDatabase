using FalconDatabase.Enums;
using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Weapon in the Campaign.
    /// </summary>
    public class WeaponDefinition
    {
        #region Properties
        /// <summary>
        /// Weapon ID.
        /// </summary>
        public short ID { get => id; set => id = value; }
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
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Hit Chance of Weapon against Targets by Movement Type.
        /// </summary>
        public Collection<byte> HitChance { get => hitChance; set => hitChance = value; }
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
        public short BlastRadius { get => blastRadius; set => blastRadius = value; }
        /// <summary>
        /// Weapon Radar Type in the Radar Database.
        /// </summary>
        public short RadarType { get => radarType; set => radarType = value; }
        /// <summary>
        /// Index into the SimWeapon Table for Campaign Engine characteristics.
        /// </summary>
        public short SimDataIdx { get => simDataIdx; set => simDataIdx = value; }
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
        private short id = 0;
        private ushort strength = 0;
        private DamageDataType damageType;
        private float range = 0;
        private ushort flags = 0;
        private string name = "";
        private Collection<byte> hitChance = [];
        private byte fireRate = 0;
        private byte rariety = 0;
        private ushort guidanceFlags = 0;
        private byte collective = 0;
        private short rackGroup = 0;
        private ushort weight = 0;
        private short dragIndex = 0;
        private short blastRadius = 0;
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
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Weapon ID: " + id);
            sb.AppendLine("Strength: " + strength);
            sb.AppendLine("Damage Type: " + damageType.ToString());
            sb.AppendLine("Range: " + range);
            sb.AppendLine("Flags: " + flags);
            sb.AppendLine("Name: " + name);
            sb.AppendLine("Statistics by Enemy Movement Type: ");
            for (int i = 0; i < HitChance.Count; i++)
            {
                sb.AppendLine("   Movement Type " + i + ":");
                sb.AppendLine("     Hit Chance: " + HitChance[i]);
            }
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
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="WeaponDefinition"/> object.
        /// </summary>
        public WeaponDefinition() { }
        #endregion Constructors     

    }
}
