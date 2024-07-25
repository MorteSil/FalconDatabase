using System.Data;
using System.Reflection;
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
        /// Index of this Entry in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Priority Value.
        /// </summary>
        public int Priority { get => priority; set => priority = value; }
        
        #endregion Properties

        #region Fields
        private int iD = 0;
        private int priority = 0;
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID: " + ID);
            sb.AppendLine("Priority: " + priority);

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="DirtyDataPriority"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\DDP.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new ();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Priority"] = Priority;   
            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="DirtyDataPriority"/> object.
        /// </summary>
        public DirtyDataPriority() { }
        /// <summary>
        /// Initializes an instance of the <see cref="DirtyDataPriority"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public DirtyDataPriority(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\DDP.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new DataSet();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            try
            {
                // Verify row conforms to Schema
                table.Rows.Add(row.ItemArray);

                // Create Object
                ID = (int)row["Num"];
                Priority = (int)row["Priority"];
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a DDP Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
