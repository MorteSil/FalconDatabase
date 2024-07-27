using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Rocket Definition for the Database.
    /// </summary>
    public class RocketDefinition
    {
        #region Properties
        /// <summary>
        /// Index into the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Index of the Pod that can fire this Rocket Object.
        /// </summary>
        public short PodIndex { get => podIndex; set => podIndex = value; }
        /// <summary>
        /// Weapon ID of the Rocket.
        /// </summary>
        public short WeaponIndex { get => weaponIndex; set => weaponIndex = value; }
        /// <summary>
        /// Number of Rockets in the Pod.
        /// </summary>
        public short WeaponCount { get => weaponCount; set => weaponCount = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private short podIndex;					// Weapon ID
        private short weaponIndex;				// new Weapon ID (if type of munition changes)
        private short weaponCount;               // number of rockets to fire


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
            sb.AppendLine("Pod ID: " + podIndex);
            sb.AppendLine("Weapon ID: " + weaponIndex);
            sb.AppendLine("Rocket Count: " + weaponCount);
            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="RocketDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\RKT.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["RocketPodIdx"] = PodIndex;
            row["RocketWpnIdx"] = WeaponIndex;
            row["RocketCount"] = WeaponCount;


            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RocketDefinition"/> object.
        /// </summary>
        public RocketDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="RocketDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public RocketDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\RKT.xsd");
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
                PodIndex = (short)row["RocketPodIdx"];
                WeaponIndex = (short)row["RocketWpnIdx"];
                WeaponCount = (short)row["RocketCount"];
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an RKT Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
