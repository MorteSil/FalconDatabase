using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// The Radar Receiver and RWR Sensor Component of the Database.
    /// </summary>
    public class RadarSensorDefinition
    {
        #region Properties
        /// <summary>
        /// Sensor Name.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Detection Range Modifier of the Sensor in reference to the default F-16 RWR.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Top Quadrant of the Sensor.
        /// </summary>
        public float TopAngle { get => top; set => top = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Bottom Quadrant of the Sensor.
        /// </summary>
        public float BottomAngle { get => bottom; set => bottom = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Left Quadrant of the Sensor.
        /// </summary>
        public float LeftAngle { get => left; set => left = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Right Quadrant of the Sensor.
        /// </summary>
        public float RightAngle { get => right; set => right = value; }
        /// <summary>
        /// Sensor Flags.
        /// </summary>
        public short Flags { get => flag; set => flag = value; }
        #endregion Properties

        #region Fields
        private string name = "";
        private float nominalRange = 0;
        private float top = 0;
        private float bottom = 0;
        private float left = 0;
        private float right = 0;
        private short flag = 0;            /* 0x01 = can get exact heading
											  0x02 = can only get vague direction
											  0x04 = can detect exact radar type
											  0x08 = can only detect group of radar types */

        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Range: " + nominalRange);
            sb.AppendLine("Top Detecion Angle: " + top);
            sb.AppendLine("Bottom Detection Angle: " + bottom);
            sb.AppendLine("Left Detection Angle: " + left);
            sb.AppendLine("Right Detection Angle: " + right);
            sb.AppendLine("Flags: " + flag);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RadarSensorDefinition"/> object.
        /// </summary>
        public RadarSensorDefinition() { }
        #endregion Constructors     

    }
}
