using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Weapon Definition in the Database.
    /// </summary>
    public class SimWeaponDefinition
    {
        #region Properties
        /// <summary>
        /// Weapon Flags.
        /// </summary>
        public int Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Drag Coefficient.
        /// </summary>
        public float DragCoefficient { get => cd; set => cd = value; }
        /// <summary>
        /// Weapon Weight.
        /// </summary>
        public float Weight { get => weight; set => weight = value; }
        /// <summary>
        /// Weapon Surface Area.
        /// </summary>
        public float Area { get => area; set => area = value; }
        /// <summary>
        /// X Component of the Ejection Velocity when the weapon is released.
        /// </summary>
        public float XEjection { get => xEjection; set => xEjection = value; }
        /// <summary>
        /// Y Component of the Ejection Velocity when the weapon is released.
        /// </summary>
        public float YEjection { get => yEjection; set => yEjection = value; }
        /// <summary>
        /// Z Component of the Ejection Velocity when the weapon is released.
        /// </summary>
        public float ZEjection { get => zEjection; set => zEjection = value; }
        /// <summary>
        /// Mnemonic displayed in the SMS Display.
        /// </summary>
        public string SMSMnemonic { get => mnemonic; set => mnemonic = value; }
        /// <summary>
        /// Weapon Class.
        /// </summary>
        public int WeaponClass { get => weaponClass; set => weaponClass = value; }
        /// <summary>
        /// Weapon Domain.
        /// </summary>
        public int Domain { get => domain; set => domain = value; }
        /// <summary>
        /// Weapon Type.
        /// </summary>
        public int WeaponType { get => weaponType; set => weaponType = value; }
        /// <summary>
        /// Weapon ID.
        /// </summary>
        public int WeaponID { get => dataIdx; set => dataIdx = value; }
        #endregion Properties

        #region Fields
        private int flags = 0;                            // Flags for the SMS
        private float cd = 0;                              // Drag coefficient
        private float weight = 0;                          // Weight
        private float area = 0;                            // sirface area for drag calc
        private float xEjection = 0;                       // Body X axis ejection velocity
        private float yEjection = 0;                       // Body Y axis ejection velocity
        private float zEjection = 0;                       // Body Z axis ejection velocity
        private string mnemonic = "";         // SMS Mnemonic
        private int weaponClass = 0;                       // SMS Weapon Class
        private int domain = 0;                            // SMS Weapon Domain
        private int weaponType = 0;                        // SMS Weapon Type
        private int dataIdx = 0;                           // Aditional characteristics data file


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Flags: " + Flags);
            sb.AppendLine("Drag Coefficient: " + DragCoefficient);
            sb.AppendLine("Weight: " + Weight);
            sb.AppendLine("Area: " + Area);
            sb.AppendLine("X Eject Velocity: " + XEjection);
            sb.AppendLine("Y Eject Velocity: " + YEjection);
            sb.AppendLine("Z Eject Velocity: " + ZEjection);
            sb.AppendLine("SMS Mnemonic: " + SMSMnemonic);
            sb.AppendLine("Weapon Class: " + WeaponClass);
            sb.AppendLine("Domain: " + +Domain);
            sb.AppendLine("Weapon Type: " + WeaponType);
            sb.AppendLine("Weapon Index: " + WeaponID);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="SimWeaponDefinition"/> object.
        /// </summary>
        public SimWeaponDefinition() { }
        #endregion Constructors     

    }
}
