using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Squadron Stores Definition in the Database.
    /// </summary>
    public class SquadronStoresDefinition
    {
        #region Properties
        /// <summary>
        /// Index in the Table
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Weapon Stores for a Squadron. Key = WeaponID, Value = Count.
        /// </summary>
        public Collection<byte> Stores
        {
            get => stores;
            set
            {
                while (value.Count > 1000) value.RemoveAt(1000);
                stores = value;
            }
        }
        /// <summary>
        /// An A-G Weapon ID that never runs out.
        /// </summary>
        public short InfiniteAG { get => infiniteAG; set => infiniteAG = value; }
        /// <summary>
        /// An A-A Weapon ID that never runs out.
        /// </summary>
        public short InfiniteAA { get => infiniteAA; set => infiniteAA = value; }
        /// <summary>
        /// A Gun Weapon ID that never runs out.
        /// </summary>
        public short InfiniteGun { get => infiniteGun; set => infiniteGun = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private Collection<byte> stores = [];	// Weapon stores (only has meaning for squadrons)
        private short infiniteAG;					            // One AG weapon we've chosen to always have available
        private short infiniteAA;					            // One AA weapon we've chosen to always have available
        private short infiniteGun;                               // Our main gun weapon, which we will always have available


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
            for (int i = 0; i < stores.Count; i++)
                if (stores[i] > 0)
                    sb.AppendLine("Weapon ID: " + i + ": " + stores[i]);
            sb.AppendLine("Infinite A-G Weapon ID: " + infiniteAG);
            sb.AppendLine("Infinite A-A Weapon ID: " + infiniteAA);
            sb.AppendLine("Infinite Gun Weapon ID: " + infiniteGun);
            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="SquadronStoresDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\SSD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["InfiniteAG"] = infiniteAG;
            row["InfiniteAA"] = infiniteAA;
            row["InfiniteGun"] = infiniteGun;
            for (int i = 0; i < 1000; i++)
            {
                if (stores[i] != 0)
                    row["WpnStores_" + i] = stores[i];
                else row["WpnStores_" + i] = DBNull.Value;
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
            hash.Add(InfiniteAA);
            hash.Add(infiniteAG);
            hash.Add(infiniteGun);
            for (int i = 0;i<stores.Count;i++)
                hash.Add(stores[i]);
            return hash.ToHashCode();
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="SquadronStoresDefinition"/> object.
        /// </summary>
        public SquadronStoresDefinition()
        {
            for (int i = 0; i < 1000; i++)
                stores.Add(0);
        }
        /// <summary>
        /// Initializes an instance of the <see cref="SquadronStoresDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public SquadronStoresDefinition(DataRow row)
            : this()
        {

            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\SSD.xsd");
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
                infiniteAG = (short)row["InfiniteAG"];
                infiniteAA = (short)row["InfiniteAA"];
                infiniteGun = (short)row["InfiniteGun"];
                for (int i = 0; i < 1000; i++)
                {
                    if (row["WpnStores_" + i] != DBNull.Value)
                        stores[i] = (byte)row["WpnStores_" + i];
                }
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an SSD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
