using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Primary Objective in the Campaign.
    /// </summary>
    public class PrimaryObjective
    {
        #region Properties
        /// <summary>
        /// Objective ID.
        /// </summary>
        public VirtualUniqueIdentifier ID { get => id; set => id = value; }
        /// <summary>
        /// Objective Priority in the Current Campaign.
        /// </summary>
        public Collection<short> Priority { get => priority; set => priority = value; }
        /// <summary>
        /// Objective Flags.
        /// </summary>
        public byte Flags { get => flags; set => flags = value; }
        #endregion Properties

        #region Fields
        private VirtualUniqueIdentifier id = new();
        private Collection<short> priority = [];
        private byte flags = 0;


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***** ID *****");
            sb.Append(ID.ToString());
            sb.AppendLine("Priority: " + priority);
            sb.AppendLine("Flags: " + flags);
            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default constructir for the <see cref="PrimaryObjective"/> object.
        /// </summary>
        public PrimaryObjective() { }
        #endregion Constructors     

    }
}
