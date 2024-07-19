using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Rocket Definition for the Database.
    /// </summary>
    public class RocketDefinition
    {
        #region Properties
        /// <summary>
        /// Index of the Pod that can fire this Rocket Object.
        /// </summary>
        public short PodIndex { get => podIndex; set => podIndex = value; }
        /// <summary>
        /// Weapon ID of the Rocket.
        /// </summary>
        public short WeaponIndex { get => weaponIndex; set => weaponIndex = value; }
        /// <summary>
        /// Number of Rockets in the Pod.
        /// </summary>
        public short WeaponCount { get => weaponCount; set => weaponCount = value; }
        #endregion Properties

        #region Fields
        private short podIndex;					// Weapon ID
        private short weaponIndex;				// new Weapon ID (if type of munition changes)
        private short weaponCount;               // number of rockets to fire


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Pod ID: " + podIndex);
            sb.AppendLine("Weapon ID: " + weaponIndex);
            sb.AppendLine("Rocket Count: " + weaponCount);
            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RocketDefinition"/> object.
        /// </summary>
        public RocketDefinition() { }
        #endregion Constructors     

    }
}
