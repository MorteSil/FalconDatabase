using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// IR Sensor Database Definition.
    /// </summary>
    public class IRSensorDefinition
    {
        #region Properties
        /// <summary>
        /// Index of this Entry in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Sensor Name.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Detection Range against F-16 Sized Target.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Field of View from Center.
        /// </summary>
        public float FOV { get => fOVHalfAngle; set => fOVHalfAngle = value; }
        /// <summary>
        /// Gimbal Limit from Center.
        /// </summary>
        public float GimbalLimit { get => gimbalLimitHalfAngle; set => gimbalLimitHalfAngle = value; }
        /// <summary>
        /// Range Multiplier applied to Ground Targets.
        /// </summary>
        public float GroundFactor { get => groundFactor; set => groundFactor = value; }
        /// <summary>
        /// Base Probability a Flare will work.
        /// </summary>
        public float FlareChance { get => flareChance; set => flareChance = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private string name = "";
        private float nominalRange = 0;
        private float fOVHalfAngle = 0;
        private float gimbalLimitHalfAngle = 0;
        private float groundFactor = 0;
        private float flareChance = 0;

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
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Range: " + Range);
            sb.AppendLine("FoV: " + FOV);
            sb.AppendLine("Gimbal Limit: " + GimbalLimit);
            sb.AppendLine("Ground Factor: " + GroundFactor);
            sb.AppendLine("Flare Chance: " + FlareChance);

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="IRSensorDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\ICD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Name"] = Name;
            row["DetectionRange"] = Range.ToString("0.0");
            row["FOV"] = FOV.ToString("0.0");
            row["GimbalLimit"] = GimbalLimit.ToString("0.0");
            row["GroundFactor"] = GroundFactor.ToString("0.000");
            row["FlareChance"] = FlareChance.ToString("0.0");

            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="IRSensorDefinition"/> object.
        /// </summary>
        public IRSensorDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="IRSensorDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public IRSensorDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\ICD.xsd");
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
                Name = (string)row["Name"];
                Range = Convert.ToSingle((decimal)row["DetectionRange"]);
                FOV = Convert.ToSingle((decimal)row["FOV"]);
                GimbalLimit = Convert.ToSingle((decimal)row["GimbalLimit"]);
                GroundFactor = Convert.ToSingle((decimal)row["GroundFactor"]);
                FlareChance = Convert.ToSingle((decimal)row["FlareChance"]);
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an ICD Entry.");
                throw;
            }
        }
        #endregion Constructors     
    }
}
