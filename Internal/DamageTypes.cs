using System.Text;
using System.Xml;

namespace FalconDatabase.Internal
{
    /// <summary>
    /// Collection of Values that pertain to each Damage Type.
    /// This is used often in the database to evaulate how weak a
    /// building or vehicle is against a specific type of damage.
    /// </summary>
    public class DamageTypes
    {
        #region Properties
        /// <summary>
        /// Weapon causes no significant damage.
        /// </summary>
        public byte NoDamage { get => noDamage; set => noDamage = value; }
        /// <summary>
        /// Weapon causes penetration damage. 
        /// Effective against hardened targets.
        /// </summary>
        public byte Penetration { get => penetration; set => penetration = value; }
        /// <summary>
        /// Weapon detonates an explosion. 
        /// Effective against soft or area targets.
        /// </summary>
        public byte HighExplosive { get => highExplosive; set => highExplosive = value; }
        /// <summary>
        /// Weapon causes heave damage leaving craters. 
        /// Effective against Runways.
        /// </summary>
        public byte Heave { get => heave; set => heave = value; }
        /// <summary>
        /// Weapon causes heat or burning damage. 
        /// Effective against troops and other soft targets.
        /// </summary>
        public byte Incendiary { get => incendiary; set => incendiary = value; }
        /// <summary>
        /// Weapon detonates an explosion when it reaches a certain proximity. 
        /// Effective against fast moving targets, such as aircraft.
        /// </summary>
        public byte Proximity { get => proximity; set => proximity = value; }
        /// <summary>
        /// Weapon fires a projective to damage the target with an impact.
        /// Effective against soft and moderately hardened targets.
        /// </summary>
        public byte Kinetic { get => kinetic; set => kinetic = value; }
        /// <summary>
        /// Weapon causes damage by detonating an underwater explosion.
        /// Effective against sea vehicles..
        /// </summary>
        public byte Hydrostatic { get => hydrostatic; set => hydrostatic = value; }
        /// <summary>
        /// Weapon causes burning damage or erodes the surface of the target.
        /// Effective against soft or moderately hardened targets.
        /// </summary>
        public byte Chemical { get => chemical; set => chemical = value; }
        /// <summary>
        /// Weapon causes significant thermal and kinetic damage through detonation of a Nuclear Device.
        /// </summary>
        public byte Nuclear { get => nuclear; set => nuclear = value; }
        /// <summary>
        /// Weapon causes general, unspecified damage to the target.
        /// </summary>
        public byte Other { get => other; set => other = value; }
        #endregion Properties

        #region Fields
        private byte noDamage = 0;
        private byte penetration = 0;
        private byte highExplosive = 0;
        private byte heave = 0;
        private byte incendiary = 0;
        private byte proximity = 0;
        private byte kinetic = 0;
        private byte hydrostatic = 0;
        private byte chemical = 0;
        private byte nuclear = 0;
        private byte other = 0;
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
            sb.AppendLine("   No Damage: " + NoDamage);
            sb.AppendLine("   Penetration: " + Penetration);
            sb.AppendLine("   High Explosive: " + HighExplosive);
            sb.AppendLine("   Heave: " + Heave);
            sb.AppendLine("   Incendiary: " + Incendiary);
            sb.AppendLine("   Proximity: " + Proximity);
            sb.AppendLine("   Kinetic: " + Kinetic);
            sb.AppendLine("   Hydrostatic: " + Hydrostatic);
            sb.AppendLine("   Chemical: " + Chemical);
            sb.AppendLine("   Nuclear: " + Nuclear);
            sb.AppendLine("   Other: " + Other);
            return sb.ToString();
        }
        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="DamageTypes"/> object.
        /// </summary>
        public DamageTypes() { }
        #endregion Constructors
    }

}
