using System.Collections.ObjectModel;
using System.Linq;
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
        /// ID of this Feature.
        /// </summary>
        public short ID { get => index; set => index = value; }
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
        public string Name
        {
            get => name;
            set => name = value;
        } // TODO: Is this still limited to 20 since XML now?
        /// <summary>
        /// How much damage the Feature can sustain before being destroyed.
        /// </summary>
        public short HitPoints { get => hitPoints; set => hitPoints = value; }
        /// <summary>
        /// Height of Vehicle Ramp if one exists.
        /// </summary>
        public short Height { get => height; set => height = value; }
        /// <summary>
        /// Angle of Vehicle Ramp if one exists.
        /// </summary>
        public float Angle { get => angle; set => angle = value; }
        /// <summary>
        /// Radar Id of an attached Radar Object if one exists.
        /// </summary>
        public short RadarType { get => radarType; set => radarType = value; }
        /// <summary>
        /// Collection of Detection Ranges for each Movement Type.
        /// </summary>
        public Collection<float> Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Collection of Damage Modifiers for each Damage Type.
        /// </summary>
        public Collection<byte> DamageMod { get => damageMod; set => damageMod = value; }
        #endregion Properties

        #region Fields
        private short index = 0;
        private short repairTime = 0;
        private byte priority = 0;
        private ushort flags = 0;
        private string name = "";
        private short hitPoints = 0;
        private short height = 0;
        private float angle = 0;
        private short radarType = 0;
        private Collection<float> detection = [];
        private Collection<byte> damageMod = [];


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Feature ID: " + ID);
            sb.AppendLine("Repair Time (hours): " + repairTime);
            sb.AppendLine("Display Priority: " + priority);
            sb.AppendLine("Flags: " + flags);
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Hit Points: " + HitPoints);
            sb.AppendLine("Vehicle Ramp Height: " + height);
            sb.AppendLine("Vehicle Ramp Angle: " + angle);
            sb.AppendLine("Radar Type: " + radarType);
            sb.AppendLine("Detection Ranges by Movement Type: ");
            for (int i = 0; i < Detection.Count; i++)
                sb.AppendLine("   " + "Movement Type " + i + ": " + detection[i]);
            sb.AppendLine("Damage Modifiers by Damage Type: ");
            for (int i = 0; i < DamageMod.Count; i++)
                sb.AppendLine("   " + "Damage Type " + i + ": " + damageMod[i]);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="FeatureDefinition"/> object.
        /// </summary>
        public FeatureDefinition() { }
        #endregion Constructors     
    }
}
