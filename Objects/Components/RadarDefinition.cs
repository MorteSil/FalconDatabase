using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Radar Object Definition.
    /// </summary>
    public class RadarDefinition
    {
        #region Properties
        /// <summary>
        /// Radar Name.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Sound to play when detected by an RWR.
        /// </summary>
        public int RWRsound { get => rwrsound; set => rwrsound = value; }
        /// <summary>
        /// Symbol to show when detected by an RWR.
        /// </summary>
        public short RWRsymbol { get => rwrsymbol; set => rwrsymbol = value; }
        /// <summary>
        /// Index into the RDr Data Table.
        /// </summary>
        public short ID { get => rdrDataIndex; set => rdrDataIndex = value; }
        /// <summary>
        /// Effectiveness against Low Altitude Targets.
        /// </summary>
        public Collection<float> Lethality { get => lethality; set => lethality = value; }
        /// <summary>
        /// Detection Range.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Width of the Beam from Center.
        /// </summary>
        public float BeamWidth { get => beamHalfAngle; set => beamHalfAngle = value; }
        /// <summary>
        /// Max Angle of the Scan Capability from Center.
        /// </summary>
        public float ScanWidth { get => scanHalfAngle; set => scanHalfAngle = value; }
        /// <summary>
        /// Speed which the Beam Sweeps.
        /// </summary>
        public float SweepRate { get => sweepRate; set => sweepRate = value; }
        /// <summary>
        /// How long the Radar will hold a lock when the target is lost.
        /// </summary>
        public float CoastTime { get => coastTime; set => coastTime = value; }
        /// <summary>
        /// How much to degrade the Signal to Noise Ratio when in a Look-Down Scenario.
        /// </summary>
        public float LookDownPenalty { get => lookDownPenalty; set => lookDownPenalty = value; }
        /// <summary>
        /// How much to degrade the Signal to Noise Ratio when in being Jammed.
        /// </summary>
        public float JammingPenalty { get => jammingPenalty; set => jammingPenalty = value; }
        /// <summary>
        /// How much to degrade the Signal to Noise Ratio when Target Aircraft Notches.
        /// </summary>
        public float NotchPenalty { get => notchPenalty; set => notchPenalty = value; }
        /// <summary>
        /// Effective Speed Target needs to fly to cause Radar to lose tracking ability.
        /// </summary>
        public float NotchSpeed { get => notchSpeed; set => notchSpeed = value; }
        /// <summary>
        /// Base probability a Chaff will be effective.
        /// </summary>
        public float ChaffChance { get => chaffChance; set => chaffChance = value; }
        /// <summary>
        /// Radar Flags.
        /// </summary>
        public short Flags { get => flag; set => flag = value; }
        #endregion Properties

        #region Fields
        private string name = "";
        private int rwrsound = 0;			            // Which sound plays in the RWR
        private short rwrsymbol = 0;			            // Which symbol shows up on the RWR
        private short rdrDataIndex = 0;		            // Index into radar data files
        private Collection<float> lethality = [];	// Lethality against low altitude targets
        private float nominalRange = 0;					// Detection range against F16 sized target
        private float beamHalfAngle = 0;					// radians (degrees in file)
        private float scanHalfAngle = 0;					// radians (degrees in file)
        private float sweepRate = 0;						// radians/sec (degrees in file)
        private float coastTime = 0;						// ms to hold lock on faded target (seconds in file)
        private float lookDownPenalty = 0;				// degrades SN ratio
        private float jammingPenalty = 0;			    // degrades SN ratio
        private float notchPenalty = 0;					// degrades SN ratio
        private float notchSpeed = 0;					// ft/sec (kts in file)
        private float chaffChance = 0;					// Base probability a bundle of chaff will decoy this radar
        private short flag = 0;                          // 0x01 = NCTR capable

        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + name);
            sb.AppendLine("RWR Sound ID: " + rwrsound);
            sb.AppendLine("RWR Symbol ID: " + rwrsymbol);
            sb.AppendLine("Radar Data Index ID: " + ID);
            sb.AppendLine("Range: " + nominalRange);
            sb.AppendLine("Beam Angle: " + beamHalfAngle);
            sb.AppendLine("Scan Angle: " + scanHalfAngle);
            sb.AppendLine("Sweep Rate: " + sweepRate);
            sb.AppendLine("Coast Time: " + coastTime);
            sb.AppendLine("Look-Down Penalty: " + lookDownPenalty);
            sb.AppendLine("Jamming Penalty: " + jammingPenalty);
            sb.AppendLine("Notch Penalty: " + notchPenalty);
            sb.AppendLine("Notch Speed: " + notchSpeed);
            sb.AppendLine("Chaff Chance: " + chaffChance);
            sb.AppendLine("Flags: " + flag);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RadarDefinition"/> object.
        /// </summary>
        public RadarDefinition() { }
        #endregion Constructors     
    }
}
