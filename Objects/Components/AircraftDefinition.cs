using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// An Aircraft Entry in the Database.
    /// </summary>
    public class AircraftDefinition
    {
        #region Properties
        /// <summary>
        /// Combat Class of the Aircraft.
        /// </summary>
        public int CombatClass { get => combatClass; set => combatClass = value; }
        /// <summary>
        /// Index into the Aircraft Table.
        /// </summary>
        public int AircraftID { get => airframeIdx; set => airframeIdx = value; }
        /// <summary>
        /// Index into the Signature Table.
        /// </summary>
        public int SignatureID { get => signatureIdx; set => signatureIdx = value; }
        /// <summary>
        /// Collection of Sensor Types on the Aircraft.
        /// </summary>
        public Collection<int> SensorType { get => sensorType; set => sensorType = value; }
        /// <summary>
        /// Index in the Sensor Table of each Sensor on the Aircraft.
        /// </summary>
        public Collection<int> SensorIndex { get => sensorIdx; set => sensorIdx = value; }
        #endregion Properties

        #region Fields
        private int combatClass = 0;                      // What type of combat does it do?
        private int airframeIdx = 0;                      // Index into airframe tables
        private int signatureIdx = 0;                     // Index into signature tables (IR only for now)
        private Collection<int> sensorType = [];          // Sensor Types [5]
        private Collection<int> sensorIdx = [];          // Index into sensor data tables [5]


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Aircraft ID: " + AircraftID);
            sb.AppendLine("Combat Class: " + CombatClass);
            sb.AppendLine("Signature ID: " + signatureIdx);
            sb.AppendLine("Sensors: ");
            for (int i = 0; i < SensorType.Count; i++)
            {
                sb.AppendLine("Sensor " + i + ":");
                sb.AppendLine("   Type: " + SensorType[i]);
                sb.AppendLine("   Index: " + SensorIndex[i]);
            }

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="AircraftDefinition"/> object.
        /// </summary>
        public AircraftDefinition() { }
        #endregion Constructors     

    }
}
