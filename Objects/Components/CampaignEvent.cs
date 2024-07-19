using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Campaign Event Entry.
    /// </summary>
    public class CampaignEvent
    {
        #region Properties
        /// <summary>
        /// Event ID.
        /// </summary>
        public short Id { get => id; set => id = value; }
        /// <summary>
        /// Event Flags.
        /// </summary>
        public short Flags { get => flags; set => flags = value; }
        #endregion Properties

        #region Fields
        private short id = 0;
        private short flags = 0;


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Event ID: " + id);
            sb.AppendLine("Event Flags: " + flags);
            return sb.ToString();
        }
        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default constructor for the <see cref="CampaignEvent"/> object.
        /// </summary>
        public CampaignEvent() { }
        #endregion Constructors
    }
}
