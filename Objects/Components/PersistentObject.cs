using FalconDatabase.GeoLib;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Persistent Object in the Campaign.
    /// </summary>
    public class PersistentObject
    {
        #region Properties
        /// <summary>
        /// X Coordinate of the Object.
        /// </summary>
        public float X { get => x; set => x = value; }
        /// <summary>
        /// Y Coordinate of the Object
        /// </summary>
        public float Y { get => y; set => y = value; }
        /// <summary>
        /// Map Coordiante Wrapper for Location of Object.
        /// </summary>
        public GeoPoint Location
        {
            get => new(x, y);
            set
            {
                x = (float)value.X;
                y = (float)value.Y;
            }
        }
        /// <summary>
        /// Unique Identifier to associate this Persistent Object with another Object in the Database.
        /// </summary>
        public PackedVirtualUniqueIdentifier UnionData { get => unionData; set => unionData = value; }
        /// <summary>
        /// The Visual Type of the Object.
        /// </summary>
        public short VisType { get => visType; set => visType = value; }
        /// <summary>
        /// Object Flags.
        /// </summary>
        public short Flags { get => flags; set => flags = value; }
        #endregion Properties

        #region Fields
        private float x;
        private float y;
        private PackedVirtualUniqueIdentifier unionData = new();
        private short visType;
        private short flags;


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Location: (" + X + ", " + Y + ")");
            sb.AppendLine("Union ID: ");
            sb.Append(UnionData.ToString());
            sb.AppendLine("Vis Type: " + VisType);
            sb.AppendLine("Flags: " + Flags);
            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default constructor for the <see cref="PersistentObject"/> object.
        /// </summary>
        public PersistentObject() { }
        #endregion Constructors     

    }
}
