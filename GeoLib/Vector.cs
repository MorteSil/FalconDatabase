namespace FalconDatabase.GeoLib
{
    /// <summary>
    /// 3D Vector.
    /// </summary>
    public class Vector
    {
        #region Properties
        /// <summary>
        /// X Vecor Component.
        /// </summary>
        public float X { get => x; set => x = value; }
        /// <summary>
        /// Y Vecor Component.
        /// </summary>
        public float Y { get => y; set => y = value; }
        /// <summary>
        /// Z Vecor Component.
        /// </summary>
        public float Z { get => z; set => z = value; }
        #endregion Properties

        #region Fields
        private float x;
        private float y;
        private float z;



        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            return "(" + X + ", " + Y + ", " + Z + ")";
        }
        #endregion Funcitonal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for <see cref="Vector"/>.
        /// </summary>
        public Vector() { }
        /// <summary>
        /// Initializes a <see cref="Vector"/> object with the supplied values.
        /// </summary>
        /// <param name="x">X Component of the Vector.</param>
        /// <param name="y">Y Component of the Vector.</param>
        /// <param name="z">Z Component of the Vector.</param>
        public Vector(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }


        #endregion Constructors
    };
}
