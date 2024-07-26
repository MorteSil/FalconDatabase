using FalconDatabase.Files;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security;

namespace FalconDatabase.Objects
{
    /// <summary>
    /// The Object Database for the Campaign.
    /// </summary>
    public class Database
    {
        #region Properties
        /// <summary>
        /// Database Class Table.
        /// </summary>
        public ClassTable Classes { get => classTable; set => classTable = value; }
        /// <summary>
        /// Database Display Priorities Table.
        /// </summary>
        public DDPTable DDPTable { get => ddpTable; set => ddpTable = value; }
        /// <summary>
        /// Database Aircraft Table.
        /// </summary>
        public AircraftTable Aircraft { get => aircraftTable; set => aircraftTable = value; }
        /// <summary>
        /// Database Feature Table.
        /// </summary>
        public FeatureTable FeatureTable { get => featureTable; set => featureTable = value; }
        /// <summary>
        /// Database IR Sensor Table.
        /// </summary>
        public IRSensorTable IrSensorTable { get => irSensorTable; set => irSensorTable = value; }
        /// <summary>
        /// Database Radar Table.
        /// </summary>
        public RadarTable RadarTable { get => radarTable; set => radarTable = value; }
        /// <summary>
        /// Radar Receiver and RWR Table.
        /// </summary>
        public RadarSensorTable RadarReceiverTable { get => radarReceiverTable; set => radarReceiverTable = value; }
        /// <summary>
        /// Rocket Table.
        /// </summary>
        public RocketTable RocketTable { get => rocketTable; set => rocketTable = value; }
        /// <summary>
        /// Squadron Stores Table.
        /// </summary>
        internal SquadronStoresTable SquadronStoresTable { get => squadronStoresTable; set => squadronStoresTable = value; }
        /// <summary>
        /// Unit Table.
        /// </summary>
        public UnitTable UnitTable { get => unitTable; set => unitTable = value; }
        /// <summary>
        /// Sim Weapons Table.
        /// </summary>
        internal SimWeaponTable WeaponTable { get => simWeaponTable; set => simWeaponTable = value; }
        /// <summary>
        /// Vehicle Table.
        /// </summary>
        public VehicleTable VehicleTable { get => vehicleTable; set => vehicleTable = value; }
        /// <summary>
        /// Visual Sensor Table.
        /// </summary>
        public VisualSensorTable VisualSensorTable { get => visualSensorTable; set => visualSensorTable = value; }
        /// <summary>
        /// Weapon Table
        /// </summary>
        public WeaponTable WeaponTable1 { get => weaponTable; set => weaponTable = value; }
        /// <summary>
        /// Rack and Hardpoint Table.
        /// </summary>
        public WeaponLoadTable WeaponLoadTable { get => weaponLoadTable; set => weaponLoadTable = value; }
        /// <summary>
        /// Objective Table.
        /// </summary>
        public ObjectiveTable ObjectiveTable { get => objectiveTable; set => objectiveTable = value; }

        #endregion Properties

        #region Fields        
        private ClassTable classTable = new();
        private DDPTable ddpTable = new();
        private AircraftTable aircraftTable = new();
        private FeatureTable featureTable = new();
        private IRSensorTable irSensorTable = new();
        private RadarTable radarTable = new();
        private RadarSensorTable radarReceiverTable = new();
        private RocketTable rocketTable = new();
        private SquadronStoresTable squadronStoresTable = new();
        private UnitTable unitTable = new();
        private SimWeaponTable simWeaponTable = new();
        private VehicleTable vehicleTable = new();
        private VisualSensorTable visualSensorTable = new();
        private WeaponTable weaponTable = new();
        private WeaponLoadTable weaponLoadTable = new();
        private ObjectiveTable objectiveTable = new();

        #endregion Fields

        #region Helper Methods       

        #endregion Helper Methods

        #region Functional Methods
        /// <summary>
        /// Saves the current Database to the specific Directory in <paramref name="saveDirectory"/>.
        /// </summary>
        /// <param name="saveDirectory">The Directory where the Database will write the Files.</param>
        /// <returns><see langword="true"/> if the Save is successful, otherwise <see langword="false"/>.</returns>
        public bool Save(string saveDirectory)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(saveDirectory);
            bool result = true;
            try
            {
                Collection<Thread> DBThreads = [];

                DBThreads.Add(new(() => { 
                    result &= classTable.Save(saveDirectory + "\\Falcon4_CT.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= ddpTable.Save(saveDirectory + "\\Falcon4_DDP.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= aircraftTable.Save(saveDirectory + "\\Falcon4_ACD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= featureTable.Save(saveDirectory + "\\Falcon4_FCD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= irSensorTable.Save(saveDirectory + "\\Falcon4_ICD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= radarTable.Save(saveDirectory + "\\Falcon4_RCD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= radarReceiverTable.Save(saveDirectory + "\\Falcon4_RWD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= rocketTable.Save(saveDirectory + "\\Falcon4_RKT.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= squadronStoresTable.Save(saveDirectory + "\\Falcon4_SSD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= unitTable.Save(saveDirectory + "\\Falcon4_UCD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= weaponTable.Save(saveDirectory + "\\Falcon4_WCD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= vehicleTable.Save(saveDirectory + "\\Falcon4_VCD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= visualSensorTable.Save(saveDirectory + "\\Falcon4_VSD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= weaponLoadTable.Save(saveDirectory + "\\Falcon4_WLD.xml");
                }));
                DBThreads.Add(new(() => {
                    result &= objectiveTable.Save(saveDirectory + "\\ObjectiveRelatedData");
                }));

                foreach (Thread t in DBThreads)
                    t.Start();

                foreach (Thread t in DBThreads)
                    t.Join();

                if (!result)
                    throw new IOException("Save Failed.");
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while Saving the Database.");
                throw;
            }

            return true;
        }
        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="Database"/> object.
        /// </summary>
        public Database() { }
        /// <summary>
        /// Searches the Directory in <paramref name="databasePath"/> and attempts to initialize a Falcon4 Datase.
        /// </summary>
        /// <param name="databasePath">The Directory Path to the Objects Folder where the Falcon4 Database XML Files are located.</param>
        /// <exception cref="ArgumentNullException">Thrown if the path in <paramref name="databasePath"/> is empty or null.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="databasePath"/> does not exist or is invalid.</exception>
        /// <exception cref="FileNotFoundException">Thrown if no Database FIles are found in <paramref name="databasePath"/>.</exception>
        /// <exception cref="SecurityException">Thrown if the Application is unable to access to location or files contained in <paramref name="databasePath"/>.</exception>
        public Database(string databasePath)
            : this()
        {
#if DEBUG
            Trace.WriteLine("Database(" + databasePath + ") Starting");
#endif

            ArgumentException.ThrowIfNullOrWhiteSpace(databasePath);
            try
            {

                DirectoryInfo? databaseDir = null;
                FileInfo? temp = null;
                FileInfo[] dbFiles = [];

                if (File.Exists(databasePath))
                {
                    temp = new FileInfo(databasePath);
                    if (temp.Directory is not null)
                        databaseDir = temp.Directory;
                }
                else if (Directory.Exists(databasePath))
                    databaseDir = new DirectoryInfo(databasePath);
                else
                    throw new ArgumentException("Path is invlaid.");

                if (databaseDir is not null)
                    dbFiles = databaseDir.GetFiles("*FALCON4_*");

                if (dbFiles.Length == 0)
                    throw new FileNotFoundException(databasePath + " did not conatin any FALCON4_XXX files.");

                Collection<Thread> DBThreads = [];

                foreach (FileInfo dbFile in dbFiles)
                {
#if DEBUG
                    Trace.WriteLine("Reading: " + dbFile.FullName);
#endif
                    
                    if (dbFile.Name.Contains("_CT"))
                    {
                        Thread ct = new(() => { classTable.Load(dbFile.FullName); });
                        DBThreads.Add(ct);
                        ct.Start();
                    }
                    else if (dbFile.Name.Contains("_DDP"))
                    {
                        Thread ddp = new(() => { ddpTable.Load(dbFile.FullName); });
                        DBThreads.Add(ddp);
                        ddp.Start();
                    }
                    else if (dbFile.Name.Contains("_ACD"))
                    {
                        Thread acd = new(() => { aircraftTable.Load(dbFile.FullName); });
                        DBThreads.Add(acd);
                        acd.Start();
                    }
                    else if (dbFile.Name.Contains("_FCD"))
                    {
                        Thread fcd = new(() => { featureTable.Load(dbFile.FullName); });
                        DBThreads.Add(fcd);
                        fcd.Start();
                    }
                    else if (dbFile.Name.Contains("_ICD"))
                    {
                        Thread icd = new(() => { irSensorTable.Load(dbFile.FullName); });
                        DBThreads.Add(icd);
                        icd.Start();
                    }
                    else if (dbFile.Name.Contains("_RCD"))
                    {
                        Thread rcd = new(() => { radarTable.Load(dbFile.FullName); });
                        DBThreads.Add(rcd);
                        rcd.Start();
                    }
                    else if (dbFile.Name.Contains("_RWD"))
                    {
                        Thread rwd = new(() => { radarReceiverTable.Load(dbFile.FullName); });
                        DBThreads.Add(rwd);
                        rwd.Start();
                    }
                    else if (dbFile.Name.Contains("_RKT"))
                    {
                        Thread rkt = new(() => { rocketTable.Load(dbFile.FullName); });
                        DBThreads.Add(rkt);
                        rkt.Start();
                    }
                    else if (dbFile.Name.Contains("_SSD"))
                    {
                        Thread ssd = new(() => { squadronStoresTable.Load(dbFile.FullName); });
                        DBThreads.Add(ssd);
                        ssd.Start();

                    }
                    else if (dbFile.Name.Contains("_UCD"))
                    {
                        Thread ucd = new(() => { unitTable.Load(dbFile.FullName); });
                        DBThreads.Add(ucd);
                        ucd.Start();
                    }
                    else if (dbFile.Name.Contains("_SWD"))
                    {
                        Thread swd = new(() => { simWeaponTable.Load(dbFile.FullName); });
                        DBThreads.Add(swd);
                        swd.Start();
                    }
                    else if (dbFile.Name.Contains("_VCD"))
                    {
                        Thread vcd = new(() => { vehicleTable.Load(dbFile.FullName); });
                        DBThreads.Add(vcd);
                        vcd.Start();
                    }
                    else if (dbFile.Name.Contains("_VSD"))
                    {
                        Thread vsd = new(() => { visualSensorTable.Load(dbFile.FullName); });
                        DBThreads.Add(vsd);
                        vsd.Start();
                    }
                    else if (dbFile.Name.Contains("_WCD"))
                    {
                        Thread wcd = new(() => { weaponTable.Load(dbFile.FullName); });
                        DBThreads.Add(wcd);
                        wcd.Start();
                    }
                    else if (dbFile.Name.Contains("_WLD"))
                    {
                        Thread wld = new(() => { weaponLoadTable.Load(dbFile.FullName); });
                        DBThreads.Add(wld);
                        wld.Start();
                    }
                }
                

                DirectoryInfo[] objectives = [];
                if (databaseDir is not null)
                    objectives = databaseDir.GetDirectories("*ObjectiveRelatedData");
#if DEBUG
                Trace.WriteLine("Starting Objectives in: " + objectives[0].FullName);
#endif
                Thread obj = new(() => { objectiveTable.Load(objectives[0].FullName); });
                DBThreads.Add(obj);
                obj.Start();

                foreach (Thread t in  DBThreads) {t.Join();}

            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading the Database.");
                throw;

            }
        }


#endregion Constructors


    }
}
