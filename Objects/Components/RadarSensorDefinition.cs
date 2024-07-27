using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// The Radar Receiver and RWR Sensor Component of the Database.
    /// </summary>
    public class RadarSensorDefinition
    {
        #region Properties
        /// <summary>
        /// Index into the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Sensor Name.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Detection Range Modifier of the Sensor in reference to the default F-16 RWR.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Top Quadrant of the Sensor.
        /// </summary>
        public float TopAngle { get => top; set => top = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Bottom Quadrant of the Sensor.
        /// </summary>
        public float BottomAngle { get => bottom; set => bottom = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Left Quadrant of the Sensor.
        /// </summary>
        public float LeftAngle { get => left; set => left = value; }
        /// <summary>
        /// Maximum Angle of Detection in the Right Quadrant of the Sensor.
        /// </summary>
        public float RightAngle { get => right; set => right = value; }
        /// <summary>
        /// Sensor Flags.
        /// </summary>
        public short Flags { get => flag; set => flag = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private string name = "";
        private float nominalRange = 0;
        private float top = 0;
        private float bottom = 0;
        private float left = 0;
        private float right = 0;
        private short flag = 0;            /* 0x01 = can get exact heading
											  0x02 = can only get vague direction
											  0x04 = can detect exact radar type
											  0x08 = can only detect group of radar types */

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
            sb.AppendLine("Range: " + nominalRange);
            sb.AppendLine("Top Detecion Angle: " + top);
            sb.AppendLine("Bottom Detection Angle: " + bottom);
            sb.AppendLine("Left Detection Angle: " + left);
            sb.AppendLine("Right Detection Angle: " + right);
            sb.AppendLine("Flags: " + flag);

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="RadarSensorDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\RWD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Name"] = Name;
            row["DetectionRange"] = Range.ToString("0.000");
            row["ScanAngleTop"] = TopAngle.ToString("0.000");
            row["ScanAngleBottom"] = BottomAngle.ToString("0.000");
            row["ScanAngleLeft"] = LeftAngle.ToString("0.000");
            row["ScanAngleRight"] = RightAngle.ToString("0.000");
            row["Flags"] = Flags;


            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RadarSensorDefinition"/> object.
        /// </summary>
        public RadarSensorDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="RadarSensorDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public RadarSensorDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\RWD.xsd");
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
                TopAngle = Convert.ToSingle((decimal)row["ScanAngleTop"]);
                BottomAngle = Convert.ToSingle((decimal)row["ScanAngleBottom"]);
                LeftAngle = Convert.ToSingle((decimal)row["ScanAngleLeft"]);
                RightAngle = Convert.ToSingle((decimal)row["ScanAngleRight"]);
                Flags = (short)row["Flags"];
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an RWD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
