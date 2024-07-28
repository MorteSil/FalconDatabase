using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Components
{
    /// <summary>
    /// Defines the types and number of Weapons that can be loaded on a Specific Rack or Hardpoint.
    /// </summary>
    public class WeaponLoadDefinition
    {
        #region Properties
        /// <summary>
        /// Index in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Rack or Hardpoint NAme.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Type and Number of each Weapon that can be loaded on this Rack or Hardpoint.
        /// </summary>
        public Collection<(short WeaponID, byte WeaponCount)> WeaponList { get => weaponList; set => weaponList = value; }


        #endregion Properties

        #region Fields
        private int iD = 0;
        private string name = "";
        private Collection<(short WeaponID, byte WeaponCount)> weaponList = [];

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
            for (int i = 0; i < weaponList.Count; i++)
                sb.AppendLine("Weapon ID: " + weaponList[i].WeaponID + " - Count: " + weaponList[i].WeaponCount);
            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="WeaponLoadDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\WLD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Name"] = Name;
            for (int i = 0; i < 64; i++)
            {
                if (WeaponList[i].WeaponID != -1)
                {
                    row["WpnIdx_" + i] = WeaponList[i].WeaponID;
                    row["WpnCount_" + i] = WeaponList[i].WeaponCount;
                }
                else
                {
                    row["WpnIdx_" + i] = DBNull.Value;
                    row["WpnCount_" + i] = DBNull.Value;
                }
            }

            return row;
        }
        /// <summary>
        /// Generates a Hash Code for the Object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(name);
            hash.Add(weaponList);

            return hash.ToHashCode();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="WeaponLoadDefinition"/> object.
        /// </summary>
        public WeaponLoadDefinition()
        {
            for (int i = 0; i < 64; i++)
                weaponList.Add((-1, 0));

        }
        /// <summary>
        /// Initializes an instance of the <see cref="WeaponLoadDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public WeaponLoadDefinition(DataRow row)
            : this()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\WLD.xsd");
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
                for (int i = 0; i < 64; i++)
                {
                    if (row["WpnIdx_" + i] != DBNull.Value)
                    {
                        weaponList[i] = ((short)row["WpnIdx_" + i], (byte)row["WpnCount_" + i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a WLD Entry.");
                throw;
            }
        }


        #endregion Constructors     

    }
}
