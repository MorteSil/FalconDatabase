using FalconDatabase.Files;
using System;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Windows;

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
                result &= classTable.Save(saveDirectory);
                result &= ddpTable.Save(saveDirectory);
                result &= aircraftTable.Save(saveDirectory);
                result &= featureTable.Save(saveDirectory);
                result &= irSensorTable.Save(saveDirectory);
                result &= radarTable.Save(saveDirectory);
                result &= radarReceiverTable.Save(saveDirectory);
                result &= rocketTable.Save(saveDirectory);
                result &= squadronStoresTable.Save(saveDirectory);
                result &= unitTable.Save(saveDirectory);
                result &= WeaponTable1.Save(saveDirectory);
                result &= VehicleTable.Save(saveDirectory);
                result &= VisualSensorTable.Save(saveDirectory);
                result &= weaponTable.Save(saveDirectory);
                result &= weaponLoadTable.Save(saveDirectory);
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


                for (int i = 0; i < dbFiles.Length; i++)
                {
#if DEBUG
                    Trace.WriteLine("Reading: " + dbFiles[i].FullName);
#endif
                    if (dbFiles[i].Name.Contains("_CT"))
                        classTable = new ClassTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_DDP"))
                        ddpTable = new DDPTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_ACD"))
                        aircraftTable = new AircraftTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_FCD"))
                        featureTable = new FeatureTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_ICD"))
                        irSensorTable = new IRSensorTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_RCD"))
                        radarTable = new RadarTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_RWD"))
                        radarReceiverTable = new RadarSensorTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_RKT"))
                        rocketTable = new RocketTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_SSD"))
                        squadronStoresTable = new SquadronStoresTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_UCD"))
                        unitTable = new UnitTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_SWD"))
                        simWeaponTable = new SimWeaponTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_VCD"))
                        vehicleTable = new VehicleTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_VSD"))
                        visualSensorTable = new VisualSensorTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_WCD"))
                        weaponTable = new WeaponTable(dbFiles[i].FullName);
                    else if (dbFiles[i].Name.Contains("_WLD"))
                        weaponLoadTable = new WeaponLoadTable(dbFiles[i].FullName);
                }
                

                DirectoryInfo[] objectives = [];
                if (databaseDir is not null)
                    objectives = databaseDir.GetDirectories("*ObjectiveRelatedData");
#if DEBUG
                Trace.WriteLine("Starting Objectives in: " + objectives[0].FullName);
#endif
                objectiveTable = new ObjectiveTable(objectives[0].FullName);
                



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
