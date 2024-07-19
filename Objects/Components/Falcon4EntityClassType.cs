using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Entity Class Type Entry in the Database Class Table.
    /// </summary>
    public class Falcon4EntityClassType
    {
        #region Properties
        /// <summary>
        /// Virtual Unit Entity Type Data.
        /// </summary>
        public VuEntityType ClassData { get => classData; set => classData = value; }
        /// <summary>
        /// Collection of Visual Type Index values.
        /// </summary>
        public Collection<short> VisualType { get => new(visualType); set => visualType = [.. value]; }
        /// <summary>
        /// The Generic Entity Type.
        /// </summary>
        public byte EntityType { get => entityType; set => entityType = value; } // TODO: Enum?
        /// <summary>
        /// Index into the Entity List.
        /// </summary>
        public short EntityIndex { get => entityIndex; set => entityIndex = value; }
        /// <summary>
        /// Unused outside the Campaign Engine.
        /// </summary>
        public int DataPtr { get => dataPtr; set => dataPtr = value; }
        #endregion Properties

        #region Fields
        private VuEntityType classData = new();
        private short[] visualType = [];
        private byte entityType = 0;
        private short entityIndex = 0;
        private int dataPtr = 0;


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***** Class Data *****");
            sb.Append(ClassData.ToString());
            sb.AppendLine("Visual Types:");
            for (int i = 0; i < visualType.Length; i++)
                sb.AppendLine("   " + visualType[i].ToString());
            sb.AppendLine("Entity Type: " + entityType);
            sb.AppendLine("Entity Index: " + EntityIndex);
            sb.AppendLine("Data Pointer: " + dataPtr);

            return sb.ToString();
        }
        #endregion Funcitonal Methods

        #region Constructors
        public Falcon4EntityClassType() { }
        #endregion Constructors

    }
}
