using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// IR Sensor Database Definition .
    /// </summary>
    public class IRSensorDefinition
    {
        #region Properties
        /// <summary>
        /// Sensor Name.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Detection Range against F-16 Sized Target.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Field of View from Center.
        /// </summary>
        public float FOV { get => fOVHalfAngle; set => fOVHalfAngle = value; }
        /// <summary>
        /// Gimbal Limit from Center.
        /// </summary>
        public float GimbalLimit { get => gimbalLimitHalfAngle; set => gimbalLimitHalfAngle = value; }
        /// <summary>
        /// Range Multiplier applied to Ground Targets.
        /// </summary>
        public float GroundFactor { get => groundFactor; set => groundFactor = value; }
        /// <summary>
        /// Base Probability a Flare will work.
        /// </summary>
        public float FlareChance { get => flareChance; set => flareChance = value; }
        #endregion Properties

        #region Fields
        private string name = "";
        private float nominalRange = 0;
        private float fOVHalfAngle = 0;
        private float gimbalLimitHalfAngle = 0;
        private float groundFactor = 0;
        private float flareChance = 0;

        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Range: " + Range);
            sb.AppendLine("FoV: " + FOV);
            sb.AppendLine("Gimbal Limit: " + GimbalLimit);
            sb.AppendLine("Ground Factor: " + GroundFactor);
            sb.AppendLine("Flare Chance: " + FlareChance);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="AircraftDefinition"/> object.
        /// </summary>
        public IRSensorDefinition() { }
        #endregion Constructors     
    }
}
