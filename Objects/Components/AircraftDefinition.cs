using FalconDatabase.Enums;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// An Aircraft Entry in the Database.
    /// </summary>
    public class AircraftDefinition
    {
        #region Properties
        /// <summary>
        /// ID of this Aircraft Definition in the Aircraft Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Combat Class of the Aircraft.
        /// </summary>
        public CombatClass CombatClass { get => combatClass; set => combatClass = value; }
        /// <summary>
        /// Index into the Aircraft Table.
        /// </summary>
        public int AircraftID { get => airframeIdx; set => airframeIdx = value; }
        /// <summary>
        /// Index into the Signature Table.
        /// </summary>
        public int IRSignatureID { get => signatureIdx; set => signatureIdx = value; }       
        /// <summary>
        /// Collection of Sensor Type and Specific Sensors on this aircraft.
        /// Item1 = SensorType Enum Sensor Type,. Item2 = ID of Sensor in the Corresponding Sensor Table
        /// </summary>
        public Collection<(SensorType SensorType, int SensorID)> Sensors 
        { 
            get => sensors;
            set
            {
                while (value.Count > 5) value.RemoveAt(5);
                sensors = value;
            } 
        }
       
        #endregion Properties

        #region Fields
        private int iD = 0;
        private CombatClass combatClass = CombatClass.LegacyFighterBomber;                    
        private int airframeIdx = 0;                     
        private int signatureIdx = 0;
        private Collection<(SensorType SensorType, int SensorID)> sensors = [];
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
            sb.AppendLine("Combat Class: " + CombatClass);
            sb.AppendLine("Aircraft ID: " + AircraftID);            
            sb.AppendLine("Signature ID: " + signatureIdx);
            sb.AppendLine("Sensors: ");
            for (int i = 0; i < Sensors.Count; i++)
            {
                sb.AppendLine("   Sensor " + i + ":");
                sb.AppendLine("     Type: " + Sensors[i].SensorType);
                sb.AppendLine("     Index: " + Sensors[i].SensorID);
            }

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="AircraftDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\ACD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new ();            
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["CombatClass"] = (int)CombatClass;
            row["AirframeDatIdx"] = AircraftID;
            row["IrSignatureIdx"] = signatureIdx;
            for (int i = 0; i < 5; i++)
            {
                if (sensors[i].SensorID != -1)
                {
                    row["SensorType_" + i] = (int)Sensors[i].SensorType;
                    row["SensorIdx_" + i] = (int)Sensors[i].SensorID;
                }
                else
                {
                    row["SensorType_" + i] = DBNull.Value;
                    row["SensorIdx_" + i] = DBNull.Value;
                }
                
            }
            
            return row;
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="AircraftDefinition"/> object.
        /// </summary>
        public AircraftDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="AircraftDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public AircraftDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\ACD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new ();            
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            try
            {
                // Verify row conforms to Schema
                table.Rows.Add(row.ItemArray);

                // Create Object
                ID = (int)table.Rows[0]["Num"];
                CombatClass = (CombatClass)row["CombatClass"];
                AircraftID = (int)row["AirframeDatIdx"];
                for (int i = 0; i < 5; i++)
                    sensors.Add(((SensorType)row["SensorType_" + i], (int)row["SensorIdx_" + i]));

            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an ACD Entry.");
                throw;
            }
            
        }
        #endregion Constructors     

    }
}
