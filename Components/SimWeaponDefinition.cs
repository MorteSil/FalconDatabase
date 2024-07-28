using System.Data;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Components
{
    /// <summary>
    /// A Weapon Definition in the Database.
    /// </summary>
    public class SimWeaponDefinition
    {
        #region Properties
        /// <summary>
        /// Index into the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
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
        public float XEjection { get => ejectionVector.X; set => ejectionVector.X = value; }
        /// <summary>
        /// Y Component of the Ejection Velocity when the weapon is released.
        /// </summary>
        public float YEjection { get => ejectionVector.Y; set => ejectionVector.Y = value; }
        /// <summary>
        /// Z Component of the Ejection Velocity when the weapon is released.
        /// </summary>
        public float ZEjection { get => ejectionVector.Z; set => ejectionVector.Z = value; }
        /// <summary>
        /// Mnemonic displayed in the SMS Display.
        /// </summary>
        public string SMSMnemonic { get => string.IsNullOrWhiteSpace(mnemonic) ? " " : mnemonic; set => mnemonic = value; }
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
        /// <summary>
        /// 3D Vector that represents the initial direction and speed of a deployed weapon.
        /// </summary>
        public Vector3 EjectionVector { get => ejectionVector; set => ejectionVector = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private int flags = 0;                            // Flags for the SMS
        private float cd = 0;                              // Drag coefficient
        private float weight = 0;                          // Weight
        private float area = 0;                            // sirface area for drag calc        
        private Vector3 ejectionVector = new(0, 0, 0);
        private string mnemonic = "";         // SMS Mnemonic
        private int weaponClass = 0;                       // SMS Weapon Class
        private int domain = 0;                            // SMS Weapon Domain
        private int weaponType = 0;                        // SMS Weapon Type
        private int dataIdx = 0;                           // Aditional characteristics data file


        #endregion Fields

        #region Functional Methods
        /// <summary>
        /// <para>Formats the data contained within this object into Readable Text.</para>
        /// <para>Readable Text does not always match the underlying file format and should not be used to save text based files such as .xml, .ini, .lst, or .txtpb files.</para>
        /// <para>Instead, use Write() to format all text or binary data for writing to a file.</para>
        /// </summary>
        /// <returns>A formatted <see cref="string"/> with the Data contained within the object.</returns>
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("ID: " + ID);
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
        /// <summary>
        /// Formats the <see cref="SimWeaponDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\SWD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Flags"] = Flags;
            row["Drag"] = DragCoefficient;
            row["Weight"] = Weight;
            row["Area"] = Area;
            row["EjectX"] = XEjection;
            row["EjectY"] = YEjection;
            row["EjectZ"] = ZEjection;
            row["WpnName"] = SMSMnemonic;
            row["WpnClass"] = WeaponClass;
            row["Domain"] = Domain;
            row["WpnType"] = WeaponType;
            row["WpnDatIdx"] = WeaponID;

            return row;
        }
        /// <summary>
        /// Generates a Hash Code for the Object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(flags);
            hash.Add(cd);
            hash.Add(weight);
            hash.Add(area);
            hash.Add(ejectionVector);
            hash.Add(mnemonic);
            hash.Add(weaponClass);
            hash.Add(domain);
            hash.Add(weaponType);
            hash.Add(dataIdx);
            return hash.ToHashCode();
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="SimWeaponDefinition"/> object.
        /// </summary>
        public SimWeaponDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="SimWeaponDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public SimWeaponDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\SWD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            try
            {
                // Verify row conforms to Schema
                table.Rows.Add(row.ItemArray);

                // Create Object
                ID = (int)row["Num"];
                Flags = (int)row["Flags"];
                DragCoefficient = (float)row["Drag"];
                Weight = (float)row["Weight"];
                Area = (float)row["Area"];
                XEjection = (float)row["EjectX"];
                YEjection = (float)row["EjectY"];
                ZEjection = (float)row["EjectZ"];
                SMSMnemonic = (string)row["WpnName"];
                WeaponClass = (int)row["WpnClass"];
                Domain = (int)row["Domain"];
                WeaponType = (int)row["WpnType"];
                WeaponID = (int)row["WpnDatIdx"];
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an SWD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
