using FalconDatabase.Enums;
using FalconDatabase.Internal;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// A Unit in the Database.
    /// </summary>
    public class UnitDefinition
    {
        #region Properties
        /// <summary>
        /// Index into the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// ID in the Database.
        /// </summary>
        public short ClassID { get => index; set => index = value; }
        /// <summary>
        /// Primary Mission Type Score.
        /// </summary>
        public byte PrimaryRole { get => role; set => role = value; }
        /// <summary>
        /// Unit Name.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Unit Description
        /// </summary>
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// Unit Flags.
        /// </summary>
        public ushort Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Movement Type of this Unit.
        /// </summary>
        public MoveType MovementType { get => movementType; set => movementType = value; }
        /// <summary>
        /// Movement Speed of this Unit.
        /// </summary>
        public short MovementSpeed { get => movementSpeed; set => movementSpeed = value; }
        /// <summary>
        /// Maximum Range of this Unit.
        /// </summary>
        public short MaxRange { get => maxRange; set => maxRange = value; }
        /// <summary>
        /// Internal Fuel Load.
        /// </summary>
        public int Fuel { get => fuel; set => fuel = value; }
        /// <summary>
        /// Rate which the Unit burns Fuel.
        /// </summary>
        public short Rate { get => rate; set => rate = value; }
        /// <summary>
        /// Point Data Index.
        /// </summary>
        public short PtDataIndex { get => ptDataIndex; set => ptDataIndex = value; }
        /// <summary>
        /// Vehicle ID of a Radar Vehicle in the Unit.
        /// </summary>
        public short RadarVehicle { get => radarVehicle; set => radarVehicle = value; }
        /// <summary>
        /// Variable Indexer into other Tables, such as the Squadron Stores Table for Squadrons.
        /// </summary>
        public short SquadronStoresID { get => specialIndex; set => specialIndex = value; }
        /// <summary>
        /// Icon Index.
        /// </summary>
        public short IconIndex { get => iconIndex; set => iconIndex = value; }
        /// <summary>
        /// Hit Chance against Targets with a given Movement Type.
        /// </summary>
        public MovementTypes HitChance { get => hitChance; set => hitChance = value; }
        /// <summary>
        /// Hit Chance against Targets with a given Movement Type.
        /// </summary>
        public MovementTypes Strength { get => strength; set => strength = value; }
        /// <summary>
        /// Range against Targets with a given Movement Type.
        /// </summary>
        public MovementTypes Range { get => range; set => range = value; }
        /// <summary>
        /// Detection against Targets with a given Movement Type.
        /// </summary>
        public MovementTypes Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Damage Modifier against Targets with a given Movement Type.
        /// </summary>
        public DamageTypes DamageModifiers { get => damageMod; set => damageMod = value; }
        /// <summary>
        /// Mission Type Score Value.
        /// </summary>
        public Collection<(int RoleType, byte RoleScore)> Scores
        {
            get => scores;
            set
            {
                while (value.Count > 16) { value.RemoveAt(16); }
                scores = value;
            }
        }
        /// <summary>
        /// The Elements that make up this Unit.
        /// </summary>
        public Collection<(byte VehicleCount, int VehicleID, int ElementFlags)> Elements
        {
            get => elements;
            set
            {
                while (value.Count > 16) { value.RemoveAt(16); }
                elements = value;
            }
        }
        /// <summary>
        /// Element Names.
        /// </summary>
        public Collection<string> ElementNames
        {
            get => elementNames;
            set
            {
                while (value.Count > 16) value.RemoveAt(16);
                elementNames = value;
            }
        }
        /// <summary>
        /// Element Name Prefixes.
        /// </summary>
        public Collection<string> ElementNamePrefixes
        {
            get => elementNamePrefixes;
            set
            {
                while (value.Count > 16) value.RemoveAt(16);
                elementNamePrefixes = value;
            }
        }
        /// <summary>
        /// Hull Numbers for the Unit.
        /// </summary>
        public Collection<short> ElementHullNumbers { get => elementHullNumbers; set => elementHullNumbers = value; }
        /// <summary>
        /// Textures for the Elements.
        /// </summary>
        public Collection<short> ElementTextureSets { get => elementTextureSets; set => elementTextureSets = value; }
        /// <summary>
        /// Unit Decals
        /// </summary>
        public Collection<short> ElementDecals { get => elementDecals; set => elementDecals = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private short index;
        private byte role = 0;
        private string name = "";
        private string description = "";
        private ushort flags = 0;
        private MoveType movementType = MoveType.NoMove;
        private short movementSpeed = 0;
        private short maxRange = 0;
        private int fuel = 0;
        private short rate = 0;
        private short ptDataIndex = 0;
        private short radarVehicle = 0;
        private short specialIndex = 0;
        private short iconIndex = 0;

        private MovementTypes hitChance = new();
        private MovementTypes strength = new();
        private MovementTypes range = new();
        private MovementTypes detection = new();
        private DamageTypes damageMod = new();

        private Collection<(int RoleType, byte RoleScore)> scores = [];
        private Collection<(byte VehicleCount, int VehicleID, int ElementFlags)> elements = [];
        private Collection<string> elementNames = [];
        private Collection<string> elementNamePrefixes = [];
        private Collection<short> elementHullNumbers = [];
        private Collection<short> elementTextureSets = [];
        private Collection<short> elementDecals = [];

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
            sb.AppendLine("Unit Class ID: " + index);
            sb.AppendLine("Elements: ");
            for (int i = 0; i < Elements.Count; i++)
            {
                sb.AppendLine("Element " + i + ": ");
                sb.AppendLine("   Vehicle Type: " + Elements[i].VehicleID);
                sb.AppendLine("   Vehicle Count: " + Elements[i].VehicleCount);
                sb.AppendLine("   Element Flags: " + Elements[i].ElementFlags);
            }
            sb.AppendLine("Unit Flags: " + Flags);
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("Movement Type: " + MovementType);
            sb.AppendLine("Speed: " + MovementSpeed);
            sb.AppendLine("Max Range: " + MaxRange);
            sb.AppendLine("Fuel: " + Fuel);
            sb.AppendLine("Fuel Burn Rate: " + Rate);
            sb.AppendLine("Point Data Index: " + PtDataIndex);
            sb.AppendLine("Mission SCores: ");
            for (int i = 0; i < Scores.Count; i++)
                sb.AppendLine("   Mission Type: " + Scores[i]);
            sb.AppendLine("Primary Role: " + PrimaryRole);
            sb.AppendLine("Statistics by Enemy Movement Type: ");
            sb.Append(hitChance.ToString());
            sb.Append(strength.ToString());
            sb.Append(range.ToString());
            sb.Append((detection.ToString()));
            sb.AppendLine("Damage Modifiers by Damage Type: ");
            sb.Append(DamageModifiers.ToString());
            sb.AppendLine("Radar Vehicle Type: " + RadarVehicle);
            sb.AppendLine("Special Index: " + SquadronStoresID);
            sb.AppendLine("Icon Index: " + IconIndex);

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="UnitDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\UCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["CtIdx"] = ClassID;
            row["MainRole"] = PrimaryRole;
            row["Name"] = Name;
            row["MoveType"] = (byte)MovementType;
            row["MoveSpeed"] = MovementSpeed;
            row["MaxRange"] = MaxRange;
            row["Fuel"] = Fuel;
            row["FuelRate"] = Rate;
            row["PtDataIdx"] = PtDataIndex;
            row["RadarVehicle"] = RadarVehicle;
            row["SquadronStoresIdx"] = SquadronStoresID;
            row["UnitIcon"] = IconIndex;
            row["Flags"] = Flags;
            row["Description"] = Description == " " ? DBNull.Value : Description;

            {
                row["Hit_NoMove"] = (byte)HitChance.NoMovement;
                row["Hit_Foot"] = (byte)HitChance.Foot;
                row["Hit_Wheeled"] = (byte)HitChance.Wheeled;
                row["Hit_Tracked"] = (byte)HitChance.Tracked;
                row["Hit_LowAir"] = (byte)HitChance.LowAir;
                row["Hit_Air"] = (byte)HitChance.Air;
                row["Hit_Naval"] = (byte)HitChance.Naval;
                row["Hit_Rail"] = (byte)HitChance.Rail;
            }

            {
                row["Str_NoMove"] = (byte)Strength.NoMovement;
                row["Str_Foot"] = (byte)Strength.Foot;
                row["Str_Wheeled"] = (byte)Strength.Wheeled;
                row["Str_Tracked"] = (byte)Strength.Tracked;
                row["Str_LowAir"] = (byte)Strength.LowAir;
                row["Str_Air"] = (byte)Strength.Air;
                row["Str_Naval"] = (byte)Strength.Naval;
                row["Str_Rail"] = (byte)Strength.Rail;
            }

            {
                row["Rng_NoMove"] = (byte)Range.NoMovement;
                row["Rng_Foot"] = (byte)Range.Foot;
                row["Rng_Wheeled"] = (byte)Range.Wheeled;
                row["Rng_Tracked"] = (byte)Range.Tracked;
                row["Rng_LowAir"] = (byte)Range.LowAir;
                row["Rng_Air"] = (byte)Range.Air;
                row["Rng_Naval"] = (byte)Range.Naval;
                row["Rng_Rail"] = (byte)Range.Rail;
            }

            {
                row["Det_NoMove"] = Detection.NoMovement.ToString("0.000");
                row["Det_Foot"] = Detection.Foot.ToString("0.000");
                row["Det_Wheeled"] = Detection.Wheeled.ToString("0.000");
                row["Det_Tracked"] = Detection.Tracked.ToString("0.000");
                row["Det_LowAir"] = Detection.LowAir.ToString("0.000");
                row["Det_Air"] = Detection.Air.ToString("0.000");
                row["Det_Naval"] = Detection.Naval.ToString("0.000");
                row["Det_Rail"] = Detection.Rail.ToString("0.000");
            }

            {
                row["Dam_None"] = damageMod.NoDamage;
                row["Dam_Penetration"] = damageMod.Penetration;
                row["Dam_HighExplosive"] = damageMod.HighExplosive;
                row["Dam_Heave"] = damageMod.Heave;
                row["Dam_Incendairy"] = damageMod.Incendiary;
                row["Dam_Proximity"] = damageMod.Proximity;
                row["Dam_Kinetic"] = damageMod.Kinetic;
                row["Dam_Hydrostatic"] = damageMod.Hydrostatic;
                row["Dam_Chemical"] = damageMod.Chemical;
                row["Dam_Nuclear"] = damageMod.Nuclear;
                row["Dam_Other"] = damageMod.Other;
            }

            for (int i = 0; i < 16; i++)
            {
                row["RoleScore_" + i] = scores[i].RoleScore;
                if (elements[i].VehicleCount != 0)
                    row["ElementCount_" + i] = elements[i].VehicleCount;
                if (elements[i].VehicleID != 0)
                    row["VehicleCtIdx_" + i] = elements[i].VehicleID;
                if (elements[i].ElementFlags != 0)
                    row["ElementFlags_" + i] = (int)elements[i].ElementFlags;
                if (elementNames[i] != " ")
                    row["ElementName_" + i] = elementNames[i];
                else row["ElementName_" + i] = DBNull.Value;
                if (elementNamePrefixes[i] != " ")
                    row["ElementNamePrefix_" + i] = elementNamePrefixes[i];
                else row["ElementNamePrefix_" + i] = DBNull.Value;
                if (elementHullNumbers[i] != -1)
                    row["ElementHullNumber_" + i] = elementHullNumbers[i];
                else row["ElementHullNumber_" + i] = DBNull.Value;
                if (elementDecals[i] != -1)
                    row["ElementDecalIdx_" + i] = elementDecals[i];
                else row["ElementDecalIdx_" + i] = DBNull.Value;
                if (elementTextureSets[i] != -1)
                    row["ElementTexSetIdx_" + i] = elementTextureSets[i];
                else row["ElementTexSetIdx_" + i] = DBNull.Value;
            }

            return row;
        }

        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="UnitDefinition"/> object.
        /// </summary>
        public UnitDefinition()
        {
            for (int i = 0; i < 16; i++)
            {
                scores.Add((i, 0));
                elements.Add((0, 0, 0));
                elementNames.Add(" ");
                elementNamePrefixes.Add(" ");
                elementHullNumbers.Add(-1);
                elementTextureSets.Add(-1);
                elementDecals.Add(-1);
            }
        }
        /// <summary>
        /// Initializes an instance of the <see cref="UnitDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public UnitDefinition(DataRow row)
            : this()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\UCD.xsd");
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
                ClassID = (short)row["CtIdx"];
                PrimaryRole = (byte)row["MainRole"];
                Name = (string)row["Name"];
                MovementType = (MoveType)(byte)row["MoveType"];
                MovementSpeed = (short)row["MoveSpeed"];
                MaxRange = (short)row["MaxRange"];
                Fuel = (int)row["Fuel"];
                Rate = (short)row["FuelRate"];
                PtDataIndex = (short)row["PtDataIdx"];
                RadarVehicle = (short)row["RadarVehicle"];
                SquadronStoresID = (short)row["SquadronStoresIdx"];
                IconIndex = (short)row["UnitIcon"];
                Flags = (ushort)row["Flags"];
                Description = row["Description"] == DBNull.Value ? " " : (string)row["Description"];

                {
                    HitChance.NoMovement = (byte)row["Hit_NoMove"];
                    HitChance.Foot = (byte)row["Hit_Foot"];
                    HitChance.Wheeled = (byte)row["Hit_Wheeled"];
                    HitChance.Tracked = (byte)row["Hit_Tracked"];
                    HitChance.LowAir = (byte)row["Hit_LowAir"];
                    HitChance.Air = (byte)row["Hit_Air"];
                    HitChance.Naval = (byte)row["Hit_Naval"];
                    HitChance.Rail = (byte)row["Hit_Rail"];
                }

                {
                    Strength.NoMovement = (byte)row["Str_NoMove"];
                    Strength.Foot = (byte)row["Str_Foot"];
                    Strength.Wheeled = (byte)row["Str_Wheeled"];
                    Strength.Tracked = (byte)row["Str_Tracked"];
                    Strength.LowAir = (byte)row["Str_LowAir"];
                    Strength.Air = (byte)row["Str_Air"];
                    Strength.Naval = (byte)row["Str_Naval"];
                    Strength.Rail = (byte)row["Str_Rail"];
                }

                {
                    Range.NoMovement = (byte)row["Rng_NoMove"];
                    Range.Foot = (byte)row["Rng_Foot"];
                    Range.Wheeled = (byte)row["Rng_Wheeled"];
                    Range.Tracked = (byte)row["Rng_Tracked"];
                    Range.LowAir = (byte)row["Rng_LowAir"];
                    Range.Air = (byte)row["Rng_Air"];
                    Range.Naval = (byte)row["Rng_Naval"];
                    Range.Rail = (byte)row["Rng_Rail"];
                }

                {
                    Detection.NoMovement = Convert.ToSingle((decimal)row["Det_NoMove"]);
                    Detection.Foot = Convert.ToSingle((decimal)row["Det_Foot"]);
                    Detection.Wheeled = Convert.ToSingle((decimal)row["Det_Wheeled"]);
                    Detection.Tracked = Convert.ToSingle((decimal)row["Det_Tracked"]);
                    Detection.LowAir = Convert.ToSingle((decimal)row["Det_LowAir"]);
                    Detection.Air = Convert.ToSingle((decimal)row["Det_Air"]);
                    Detection.Naval = Convert.ToSingle((decimal)row["Det_Naval"]);
                    Detection.Rail = Convert.ToSingle((decimal)row["Det_Rail"]);
                }

                {
                    damageMod.NoDamage = (byte)row["Dam_None"];
                    damageMod.Penetration = (byte)row["Dam_Penetration"];
                    damageMod.HighExplosive = (byte)row["Dam_HighExplosive"];
                    damageMod.Heave = (byte)row["Dam_Heave"];
                    damageMod.Incendiary = (byte)row["Dam_Incendairy"];
                    damageMod.Proximity = (byte)row["Dam_Proximity"];
                    damageMod.Kinetic = (byte)row["Dam_Kinetic"];
                    damageMod.Hydrostatic = (byte)row["Dam_Hydrostatic"];
                    damageMod.Chemical = (byte)row["Dam_Chemical"];
                    damageMod.Nuclear = (byte)row["Dam_Nuclear"];
                    damageMod.Other = (byte)row["Dam_Other"];
                }

                for (int i = 0; i < 16; i++)
                {
                    if (row["RoleScore_" + i] != DBNull.Value)
                        scores[i] = (i, (byte)row["RoleScore_" + i]);
                    if (row["ElementCount_" + i] != DBNull.Value)
                        elements[i] = ((byte)row["ElementCount_" + i], elements[i].VehicleID, elements[i].ElementFlags);
                    if (row["VehicleCtIdx_" + i] != DBNull.Value)
                        elements[i] = (elements[i].VehicleCount, (int)row["VehicleCtIdx_" + i], elements[i].ElementFlags);
                    if (row["ElementFlags_" + i] != DBNull.Value)
                        elements[i] = (elements[i].VehicleCount, elements[i].VehicleID, (int)row["ElementFlags_" + i]);
                    if (row["ElementName_" + i] != DBNull.Value)
                        elementNames[i] = (string)row["ElementName_" + i];
                    if (row["ElementNamePrefix_" + i] != DBNull.Value)
                        elementNamePrefixes[i] = (string)row["ElementNamePrefix_" + i];
                    if (row["ElementHullNumber_" + i] != DBNull.Value)
                        elementHullNumbers[i] = (short)row["ElementHullNumber_" + i];
                    if (row["ElementDecalIdx_" + i] != DBNull.Value)
                        elementDecals[i] = (short)row["ElementDecalIdx_" + i];
                    if (row["ElementTexSetIdx_" + i] != DBNull.Value)
                        elementTextureSets[i] = (short)row["ElementTexSetIdx_" + i];
                }
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a UCD Entry.");
                throw;
            }
        }
        #endregion Constructors     

    }
}
