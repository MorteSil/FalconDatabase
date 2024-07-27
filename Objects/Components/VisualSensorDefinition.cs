using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Visual Sensor in the Campaign.
    /// </summary>
    public class VisualSensorDefinition
    {
        #region Properties
        /// <summary>
        /// Index in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Sensor Name.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Range of the Sensor.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Top View Angle from Center.
        /// </summary>
        public float Top { get => top; set => top = value; }
        /// <summary>
        /// Bottom View Angle from Center.
        /// </summary>
        public float Bottom { get => bottom; set => bottom = value; }
        /// <summary>
        /// Left View Angle from Center.
        /// </summary>
        public float Left { get => left; set => left = value; }
        /// <summary>
        /// Right View Angle from Center.
        /// </summary>
        public float Right { get => right; set => right = value; }


        #endregion Properties

        #region Fields
        private int iD = 0;
        string name = "";
        private float nominalRange = 0;              // Nominal detection range
        private float top = 0;                       // Scan volume top (Degrees in text file)
        private float bottom = 0;                    // Scan volume bottom (Degrees in text file)
        private float left = 0;                      // Scan volume left (Degrees in text file)
        private float right = 0;                     // Scan volume right (Degrees in text file)


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
            sb.AppendLine("Range: " + Range);
            sb.AppendLine("Top Angle: " + Top);
            sb.AppendLine("Bottom Angle: " + Bottom);
            sb.AppendLine("Left Angle: " + Left);
            sb.AppendLine("Right Angle: " + Right);
            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="VisualSensorDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\VSD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Name"] = Name;
            row["DetectionRange"] = Range.ToString("0.000");
            row["ScanAngleTop"] = Top.ToString("0.000");
            row["ScanAngleBottom"] = Bottom.ToString("0.000");
            row["ScanAngleLeft"] = Left.ToString("0.000");
            row["ScanAngleRight"] = Right.ToString("0.000");

            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="VisualSensorDefinition"/> object.
        /// </summary>
        public VisualSensorDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="VisualSensorDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public VisualSensorDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\VSD.xsd");
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
                Top = Convert.ToSingle((decimal)row["ScanAngleTop"]);
                Bottom = Convert.ToSingle((decimal)row["ScanAngleBottom"]);
                Left = Convert.ToSingle((decimal)row["ScanAngleLeft"]);
                Right = Convert.ToSingle((decimal)row["ScanAngleRight"]);
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a VSD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
