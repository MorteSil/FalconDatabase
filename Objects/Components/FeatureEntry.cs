using FalconDatabase.GeoLib;
using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Component of a Feature.
    /// </summary>
    class FeatureEntry
    {
        #region Properties
        /// <summary>
        /// Feature ID.
        /// </summary>
        public short Index { get => index; set => index = value; }
        /// <summary>
        /// Flags.
        /// </summary>
        public ushort Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Class Entities contained within the Feature Entity.
        /// </summary>
        public Collection<byte> FeatureClasses { get => eClass; set => eClass = value; }
        /// <summary>
        /// Percentage of operational loss if destroyed.
        /// </summary>
        public byte Value { get => value; set => this.value = value; }
        /// <summary>
        /// Offset of Component from the Feature Coordinates.
        /// </summary>
        public Vector Offset { get => offset; set => offset = value; }
        /// <summary>
        /// The Direction the Component is facing.
        /// </summary>
        public short Facing { get => facing; set => facing = value; }
        #endregion Properties

        #region Fields
        private short index = 0;
        private ushort flags = 0;
        private Collection<byte> eClass = []; // [8]
        private byte value = 0;
        private Vector offset = new(0, 0, 0);
        private short facing = 0;


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Feature Index: " + index);
            sb.AppendLine("Flags: " + flags);
            sb.AppendLine("Components Entities: ");
            for (int i = 0; i < eClass.Count; i++)
                sb.AppendLine("   Component ID: " + eClass[i]);
            sb.AppendLine("Offset: " + offset.ToString());
            sb.AppendLine("Front Facing Direction: " + facing);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="FeatureEntry"/> object.
        /// </summary>
        public FeatureEntry() { }
        #endregion Constructors     
    }
}
