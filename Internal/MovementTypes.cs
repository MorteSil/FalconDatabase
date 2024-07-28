using System.Text;
using System.Xml;

namespace FalconDatabase.Internal
{
    /// <summary>
    /// Collection of Values that pertain to each Movement Type.
    /// This is used often in the database to evaulate wepon or vehicle effectiveness
    /// against each type of Movement.
    /// </summary>
    public class MovementTypes
    {
        #region Properties
        /// <summary>
        /// Object is stationary and cannot move.
        /// </summary>
        public double NoMovement { get => noMovement; set => noMovement = value; }
        /// <summary>
        /// Object is a pedestrian and moves by using it's feet.
        /// </summary>
        public double Foot { get => foot; set => foot = value; }
        /// <summary>
        /// Object uses Wheels to travel across land.
        /// </summary>
        public double Wheeled { get => wheeled; set => wheeled = value; }
        /// <summary>
        /// Object used a large, flxible component wrapped around several wheels to move across land with better traction.
        /// </summary>
        public double Tracked { get => tracked; set => tracked = value; }
        /// <summary>
        /// Object travels through the air at low altitudes, such as a helicopter.
        /// </summary>
        public double LowAir { get => lowAir; set => lowAir = value; }
        /// <summary>
        /// Object travels through the air at various high and low altitudes.
        /// </summary>
        public double Air { get => air; set => air = value; }
        /// <summary>
        /// Object moves thorugh the water.
        /// </summary>
        public double Naval { get => naval; set => naval = value; }
        /// <summary>
        /// Object travels along tracks or rails.
        /// </summary>
        public double Rail { get => rail; set => rail = value; }
        #endregion Properties

        #region Fields
        private double noMovement = 0;
        private double foot = 0;
        private double wheeled = 0;
        private double tracked = 0;
        private double lowAir = 0;
        private double air = 0;
        private double naval = 0;
        private double rail = 0;
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
            sb.AppendLine("   No Movement: " + NoMovement);
            sb.AppendLine("   Foot: " + Foot);
            sb.AppendLine("   Wheeled: " + Wheeled);
            sb.AppendLine("   Tracked: " + Tracked);
            sb.AppendLine("   Low Air: " + LowAir);
            sb.AppendLine("   Air: " + Air);
            sb.AppendLine("   Naval :" + Naval);
            sb.AppendLine("   Rail: " + Rail);
            return sb.ToString();
        }

        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default constructor for the <see cref="MovementTypes"/> object.
        /// </summary>
        public MovementTypes() { }
        #endregion Constructors
    }
}
