using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// An DDP Record in the Database.
    /// </summary>
    public class DirtyDataPriority
    {
        #region Properties
        /// <summary>
        /// Priority Value.
        /// </summary>
        public int Priority { get => priority; set => priority = value; }
        #endregion Properties

        #region Fields
        private int priority = 0;
        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Priority: " + priority);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="DirtyDataPriority"/> object.
        /// </summary>
        public DirtyDataPriority() { }
        #endregion Constructors     

    }
}
