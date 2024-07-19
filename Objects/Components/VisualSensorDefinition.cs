using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Visual Sensor in the Campaign.
    /// </summary>
    public class VisualSensorDefinition
    {
        #region Properties
        /// <summary>
        /// Sensor Name.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Range of the Sensor.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Top View Angle from Center.
        /// </summary>
        public float Top { get => top; set => top = value; }
        /// <summary>
        /// Bottom View Angle from Center.
        /// </summary>
        public float Bottom { get => bottom; set => bottom = value; }
        /// <summary>
        /// Left View Angle from Center.
        /// </summary>
        public float Left { get => left; set => left = value; }
        /// <summary>
        /// Right View Angle from Center.
        /// </summary>
        public float Right { get => right; set => right = value; }

        #endregion Properties

        #region Fields
        string name = "";
        private float nominalRange = 0;              // Nominal detection range
        private float top = 0;                       // Scan volume top (Degrees in text file)
        private float bottom = 0;                    // Scan volume bottom (Degrees in text file)
        private float left = 0;                      // Scan volume left (Degrees in text file)
        private float right = 0;                     // Scan volume right (Degrees in text file)


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Range: " + Range);
            sb.AppendLine("Top Angle: " + Top);
            sb.AppendLine("Bottom Angle: " + Bottom);
            sb.AppendLine("Left Angle: " + Left);
            sb.AppendLine("Right Angle: " + Right);
            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="VisualSensorDefinition"/> object.
        /// </summary>
        public VisualSensorDefinition() { }
        #endregion Constructors     

    }
}
