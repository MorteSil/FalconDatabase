using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Pilot in the Campaign.
    /// </summary>
    public class PilotInfo
    {
        #region Properties
        /// <summary>
        /// Number of times this Pilot is used.
        /// </summary>
        public short Usage { get => usage; set => usage = value; }
        /// <summary>
        /// Voice ID Index of this Pilot.
        /// </summary>
        public byte VoiceID { get => voice_id; set => voice_id = value; }
        /// <summary>
        /// Photo ID Index of this Pilot.
        /// </summary>
        public byte PhotoID { get => photo_id; set => photo_id = value; }
        #endregion Properties

        #region Fields
        private short usage = 0;
        private byte voice_id = 0;
        private byte photo_id = 0;


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Number of Times this Pilot is Used: " + Usage);
            sb.AppendLine("Pilot Voice ID: " + VoiceID);
            sb.AppendLine("Pilot Photo ID: " + PhotoID);
            return sb.ToString();
        }
        #endregion Functinal Methods

        #region Constructors
        /// <summary>
        /// Default constructor for the <see cref="PilotInfo"/> object.
        /// </summary>
        public PilotInfo() { }
        #endregion Constructors
    }
}
