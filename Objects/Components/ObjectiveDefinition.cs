using FalconDatabase.Enums;
using FalconDatabase.Internal;
using System.Collections.ObjectModel;
using System.Data;
using System.Numerics;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// An Objective in the Database.
    /// </summary>
    public class ObjectiveDefinition
    {
        #region Properties
        /// <summary>
        /// Index of this object in the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Index in the Class Table.
        /// </summary>
        public short ClassID { get => index; set => index = value; }
        /// <summary>
        /// Name of the Objective.
        /// </summary>
        public string Name { get => string.IsNullOrEmpty(name) ? "" : name; set => name = value; }
        /// <summary>
        /// Determines how the Campaign Engine interacts with the Objective.
        /// </summary>
        public short DataRate { get => dataRate; set => dataRate = value; }
        /// <summary>
        /// Distance in feet the Bubble stays active when Entities are near in the 3D World.
        /// </summary>
        public short DeagDistance { get => deagDistance; set => deagDistance = value; }
        /// <summary>
        /// Detection Ranges for this Objective by Movement Type.
        /// </summary>
        public MovementTypes Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Damage Modifiers against this Objective by Damage Type.
        /// </summary>
        public DamageTypes DamageMod { get => damageMod; set => damageMod = value; }
        /// <summary>
        /// Icon used for this Objective.
        /// </summary>
        public short IconIndex { get => iconIndex; set => iconIndex = value; }
        /// <summary>
        /// Feature ID that provides Radar for this Objective.
        /// </summary>
        public byte RadarFeature { get => radarFeature; set => radarFeature = value; }
        /// <summary>
        /// Collection of Features for this Objective.
        /// </summary>
        public Collection<FeatureEntry> Features { get => features; set => features = value; }
        /// <summary>
        /// <para>Collection of Point Data Objects to Define special locations on the Objective.</para>
        /// <para>Points and Point Headers define abstract points associated with Landing Locations, Approach Points, etc...</para>
        /// </summary>
        public Collection<PointData> Points { get => points; set => points = value; }
        /// <summary>
        /// Contains Details for the Points in the Objective.
        /// </summary>
        public Collection<PointHeaderData> HeaderData { get => headerData; set => headerData = value; }

        #endregion Properties

        #region Fields
        private int iD = 0;
        private short index = 0;
        private string name = "";
        private short dataRate = 0;
        private short deagDistance = 0;
        private MovementTypes detection = new();
        private DamageTypes damageMod = new();
        private short iconIndex = 0;
        private byte radarFeature = 0;

        private Collection<FeatureEntry> features = [];
        private Collection<PointData> points = [];
        private Collection<PointHeaderData> headerData = [];
        #endregion Fields

        #region Helper Methods
        /// <summary>
        /// Updates the Point Header Data FirstPoint field.
        /// </summary>
        private void UpdatePHDOffsets()
        {
            ushort offset = 0;
            for (int i = 0; i < headerData.Count; i++)
            {
                headerData[i].FirstPoint = offset;
                offset += headerData[i].PointCount;
            }
        }
        #endregion Helper Methods

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
            sb.AppendLine("Objective ID: " + ClassID);
            sb.AppendLine("Name: " + Name);
            sb.AppendLine("DataRate: " + DataRate);
            sb.AppendLine("DeaggDistance: " + DeagDistance);
            sb.Append(detection.ToString());
            sb.Append(damageMod.ToString());
            sb.AppendLine("Objective Icon: " + IconIndex);
            sb.AppendLine("Radar Feature ID: " + RadarFeature);
            sb.AppendLine("***** Objective Features *****");
            foreach (FeatureEntry f in features)
                sb.Append(f.ToString());
            sb.AppendLine("***** Points *****");
            foreach (PointData p in Points)
                sb.Append(p.ToString());
            sb.AppendLine("***** Point Header Data *****");
            foreach (PointHeaderData h in HeaderData)
                sb.Append(h.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="ObjectiveDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            UpdatePHDOffsets();
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\OCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["CtIdx"] = ClassID;
            row["Name"] = Name;
            row["DataRate"] = DataRate;
            row["DeaggDistance"] = DeagDistance;
            row["ObjectiveIcon"] = IconIndex;
            row["RadarFeature"] = RadarFeature;
            {
                row["Det_NoMove"] = Detection.NoMovement;
                row["Det_Foot"] = Detection.Foot;
                row["Det_Wheeled"] = Detection.Wheeled;
                row["Det_Tracked"] = Detection.Tracked;
                row["Det_LowAir"] = Detection.LowAir;
                row["Det_Air"] = Detection.Air;
                row["Det_Naval"] = Detection.Naval;
                row["Det_Rail"] = Detection.Rail;
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


            return row;
        }
        /// <summary>
        /// Generates a Hash Code for the Object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(index);
            hash.Add(name);
            hash.Add(DataRate);
            hash.Add(deagDistance);
            hash.Add(detection);
            hash.Add(damageMod);
            hash.Add(iconIndex);
            hash.Add(radarFeature);
            return hash.ToHashCode();
        }

        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="ObjectiveDefinition"/> object.
        /// </summary>
        public ObjectiveDefinition()
        {

        }
        /// <summary>
        /// Initializes an instance of the <see cref="ObjectiveDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public ObjectiveDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\OCD.xsd");
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
                Name = (string)row["Name"];
                DataRate = (short)row["DataRate"];
                DeagDistance = (short)row["DeaggDistance"];
                IconIndex = (short)row["ObjectiveIcon"];
                RadarFeature = (byte)row["RadarFeature"];
                {
                    Detection.NoMovement = (float)row["Det_NoMove"];
                    Detection.Foot = (float)row["Det_Foot"];
                    Detection.Wheeled = (float)row["Det_Wheeled"];
                    Detection.Tracked = (float)row["Det_Tracked"];
                    Detection.LowAir = (float)row["Det_LowAir"];
                    Detection.Air = (float)row["Det_Air"];
                    Detection.Naval = (float)row["Det_Naval"];
                    Detection.Rail = (float)row["Det_Rail"];
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
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an OCD Entry.");
                throw;
            }
        }

        #endregion Constructors

        #region Subclasses
        /// <summary>
        /// A Component of a Feature.
        /// </summary>
        public class FeatureEntry
        {
            #region Properties
            /// <summary>
            /// Index of this Feature in the Objective List.
            /// </summary>
            public int ID { get => iD; set => iD = value; }
            /// <summary>
            /// Feature ID.
            /// </summary>
            public short FeatureID { get => featureID; set => featureID = value; }
            /// <summary>
            /// Percentage of operational loss if destroyed.
            /// </summary>
            public byte Value { get => value; set => this.value = value; }
            /// <summary>
            /// Offset of Component from the Feature Coordinates.
            /// </summary>
            public Vector3 Offset { get => offset; set => offset = value; }
            /// <summary>
            /// The Direction the Component is facing.
            /// </summary>
            public double Heading { get => facing; set => facing = value; }
            /// <summary>
            /// Feature Entry Flags.
            /// </summary>
            public short Flags { get => flags; set => flags = value; }

            #endregion Properties

            #region Fields
            private int iD = 0;
            private short featureID = 0;
            private byte value = 0;
            private Vector3 offset = new(0, 0, 0);
            private double facing = 0;
            private short flags = 0;
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
                sb.AppendLine("   ID: " + ID);
                sb.AppendLine("   Feature ID: " + FeatureID);
                sb.AppendLine("   Data Value: " + Value);
                sb.AppendLine("   Offset: (" + offset.X + ", " + offset.Y + ", " + offset.Z + ")");
                sb.AppendLine("   Front Facing Direction: " + facing);

                return sb.ToString();
            }
            /// <summary>
            /// Formats the <see cref="FeatureEntry"/> as a <see cref="DataRow"/>.
            /// </summary>
            /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
            public DataRow ToDataRow()
            {
                string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\FED.xsd");
                if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

                DataSet dataSet = new();
                dataSet.ReadXmlSchema(schemaFile);
                DataTable table = dataSet.Tables[0];
                DataRow row = table.NewRow();

                row["Num"] = ID;
                row["FeatureCtIdx"] = FeatureID;
                row["OffsetX"] = Offset.X.ToString("0.000");
                row["OffsetY"] = Offset.Y.ToString("0.000");
                row["OffsetZ"] = Offset.Z.ToString("0.000");
                row["Heading"] = facing.ToString("0.0");
                if (value > 0)
                    row["Value"] = Value;                
                if (flags != 0)
                    row["Flags"] = Flags;


                return row;
            }
            /// <summary>
            /// Generates a Hash Code for the Object.
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                HashCode hash = new();
                hash.Add(featureID);
                hash.Add(value);
                hash.Add(offset);
                hash.Add(flags);
                hash.Add(facing);
                return hash.ToHashCode();
            }

            #endregion Funcitnoal Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="FeatureEntry"/> object.
            /// </summary>
            public FeatureEntry() { }
            /// <summary>
            /// Initializes an instance of the <see cref="FeatureEntry"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
            /// </summary>
            /// <param name="row"></param>
            public FeatureEntry(DataRow row)
            {
                string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\FED.xsd");
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
                    FeatureID = (short)row["FeatureCtIdx"];
                    if (row["Value"] != DBNull.Value)
                        Value = (byte)row["Value"];
                    Offset = new((float)row["OffsetX"], (float)row["OffsetY"],(float)row["OffsetZ"]);
                    facing = (float)row["Heading"];
                    if (row["Flags"] != DBNull.Value)
                        Flags = (short)row["Flags"];
                    
                }
                catch (Exception ex)
                {
                    Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an FED Entry.");
                    throw;
                }
            }
            #endregion Constructors     
        }

        /// <summary>
        /// A Component of a Feature.
        /// </summary>
        public class PointData
        {
            #region Properties
            /// <summary>
            /// Index of this Feature in the Objective List.
            /// </summary>
            public int ID { get => iD; set => iD = value; }
            /// <summary>
            /// Feature ID.
            /// </summary>
            public short PointType { get => pointType; set => pointType = value; }
            /// <summary>
            /// Percentage of operational loss if destroyed.
            /// </summary>
            public int Flags { get => flags; set => flags = value; }
            /// <summary>
            /// Offset of Component from the Feature Coordinates.
            /// </summary>
            public Vector3 Offset { get => offset; set => offset = value; }
            /// <summary>
            /// Max Height of the Point.
            /// </summary>
            public double MaxHeight { get => maxHeight; set => maxHeight = value; }
            /// <summary>
            /// Max Width.
            /// </summary>
            public double MaxWidth { get => maxWidth; set => maxWidth = value; }
            /// <summary>
            /// Max Length
            /// </summary>
            public double MaxLength { get => maxLength; set => maxLength = value; }
            /// <summary>
            /// Taxiway Letter.
            /// </summary>
            public byte TaxiwayLetter { get => taxiwayLetter; set => taxiwayLetter = value; }
            /// <summary>
            /// Parking Group
            /// </summary>
            public int ParkingPointGroup { get => parkingPointGroup; set => parkingPointGroup = value; }
            /// <summary>
            /// runway Side
            /// </summary>
            public byte RunwaySide { get => runwaySide; set => runwaySide = value; }
            /// <summary>
            /// Heading
            /// </summary>
            public double Heading { get => heading; set => heading = value; }
            /// <summary>
            /// Branch Index
            /// </summary>
            public short BranchIdx { get => branchIdx; set => branchIdx = value; }
            /// <summary>
            /// Root Index
            /// </summary>
            public short RootIdx { get => rootIdx; set => rootIdx = value; }
            /// <summary>
            /// Crossing Point
            /// </summary>
            public bool CrossingPoint { get => crossingPoint; set => crossingPoint = value; }
            /// <summary>
            /// Runway Number
            /// </summary>
            public int RunwayNumber { get => runwayNumber; set => runwayNumber = value; }

            #endregion Properties

            #region Fields
            private int iD = 0;
            private short pointType = -1;
            private int flags = 0;
            private Vector3 offset = new(0, 0, 0);
            private double maxHeight = -1;
            private double maxWidth = -1;
            private double maxLength = -1;
            private byte taxiwayLetter = 255;
            private int parkingPointGroup = -10;
            private byte runwaySide = 255;
            private double heading = -1;
            private short branchIdx = -1;
            private short rootIdx = -1;
            private bool crossingPoint = false;
            private int runwayNumber = -1;
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
                sb.AppendLine("   ID: " + ID);
                sb.AppendLine("   Point Type: " + pointType);
                sb.AppendLine("   Offset: (" + offset.X + ", " + offset.Y + ", " + offset.Z + ")");
                sb.AppendLine("   Flags: " + flags);
                sb.AppendLine("   Max Height: " + maxHeight);
                sb.AppendLine("   Max Width: " + MaxWidth);
                sb.AppendLine("   Max Length: " + MaxLength);
                sb.AppendLine("   Taxiway Letter: " + TaxiwayLetter);
                sb.AppendLine("   Parking Point Group: " + parkingPointGroup);
                sb.AppendLine("   Runway Side: " + runwaySide);
                sb.AppendLine("   Heading: " + heading);
                sb.AppendLine("   Root Index: " + rootIdx.ToString());
                sb.AppendLine("   Branch Index: " + branchIdx.ToString());
                sb.AppendLine("   Crossing Point: " + crossingPoint);
                sb.AppendLine("   Runway Number: " + runwayNumber);

                return sb.ToString();
            }
            /// <summary>
            /// Formats the <see cref="PointData"/> as a <see cref="DataRow"/>.
            /// </summary>
            /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
            public DataRow ToDataRow()
            {
                string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\PDX.xsd");
                if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

                DataSet dataSet = new();
                dataSet.ReadXmlSchema(schemaFile);
                DataTable table = dataSet.Tables[0];
                DataRow row = table.NewRow();

                row["Num"] = ID;
                row["OffsetX"] = Offset.X;
                row["OffsetY"] = Offset.Y;
                row["OffsetZ"] = Offset.Z;
                if (pointType != -1)
                    row["Type"] = PointType;
                if (parkingPointGroup !=-10)
                    row["ParkingPointGroup"] = ParkingPointGroup;
                if (rootIdx != -1)
                    row["RootIdx"] = RootIdx;
                if (BranchIdx != -1)
                    row["BranchIdx"] = BranchIdx;
                if (taxiwayLetter != 255)
                    row["TaxiwayLetter"] = TaxiwayLetter;
                if (runwayNumber != -1)
                    row["RunwayNumber"] = RunwayNumber;
                if (runwaySide != 255)
                    row["RunwaySide"] = RunwaySide;
                if (flags != 0)
                    row["Flags"] = Flags;
                if (maxHeight != -1)
                    row["MaxHeight"] = MaxHeight;
                if (MaxWidth != -1)
                    row["MaxWidth"] = MaxWidth;
                if (maxLength != -1)
                    row["MaxLength"] = MaxLength;
                if (heading != -1)
                    row["Heading"] = Heading;
                if (crossingPoint)
                    row["CrossingPoint"] = CrossingPoint.ToString().ToLower();

                return row;
            }
            /// <summary>
            /// Generates a Hash Code for the Object.
            /// </summary>
            /// <returns></returns>
            public override int GetHashCode()
            {
                HashCode hash = new();
                hash.Add(pointType);
                hash.Add(flags);
                hash.Add(offset);
                hash.Add(maxHeight);
                hash.Add(maxWidth);
                hash.Add(maxLength);
                hash.Add(taxiwayLetter);
                hash.Add(parkingPointGroup);
                hash.Add(runwaySide);
                hash.Add(heading);
                hash.Add(branchIdx);
                hash.Add(crossingPoint);
                hash.Add(rootIdx);
                hash.Add(runwayNumber);
                return hash.ToHashCode();
            }
            #endregion Funcitnoal Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="PointData"/> object.
            /// </summary>
            public PointData() { }
            /// <summary>
            /// Initializes an instance of the <see cref="PointData"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
            /// </summary>
            /// <param name="row"></param>
            public PointData(DataRow row)
            {
                string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\PDX.xsd");
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
                    Offset = new((float)row["OffsetX"], (float)row["OffsetY"], (float)row["OffsetZ"]);
                    if (row["Type"] != DBNull.Value)
                        PointType = (byte)row["Type"];
                    if (row["ParkingPointGroup"] != DBNull.Value)
                        ParkingPointGroup = (int)row["ParkingPointGroup"];
                    if (row["RootIdx"] != DBNull.Value)
                        RootIdx = (short)row["RootIdx"];
                    if (row["BranchIdx"] != DBNull.Value)
                        BranchIdx = (short)row["BranchIdx"];
                    if (row["TaxiwayLetter"] != DBNull.Value)
                        TaxiwayLetter = (byte)row["TaxiwayLetter"];
                    if (row["RunwayNumber"] != DBNull.Value)
                        RunwayNumber = (int)row["RunwayNumber"];
                    if (row["RunwaySide"] != DBNull.Value)
                        RunwaySide = (byte)row["RunwaySide"];
                    if (row["Flags"] != DBNull.Value)
                        Flags = (int)row["Flags"];
                    if (row["MaxHeight"] != DBNull.Value)
                        MaxHeight = (float)row["MaxHeight"];
                    if (row["MaxWidth"] != DBNull.Value)
                        MaxWidth = (float)row["MaxWidth"];
                    if (row["MaxLength"] != DBNull.Value)
                        MaxLength = (float)row["MaxLength"];
                    if (row["Heading"] != DBNull.Value)
                        Heading = (float)row["Heading"];
                    if (row["CrossingPoint"] != DBNull.Value)
                        CrossingPoint = bool.Parse((string)row["CrossingPoint"]);
                }
                catch (Exception ex)
                {
                    Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a PDX Entry.");
                    throw;
                }
            }
            #endregion Constructors     
        }

        /// <summary>
        /// A Component of a Feature.
        /// </summary>
        public class PointHeaderData
        {
            #region Properties
            /// <summary>
            /// Index of this Feature in the Objective List.
            /// </summary>
            public int ID { get => iD; set => iD = value; }
            /// <summary>
            /// Objective this Point Belongs to.
            /// </summary>
            public short ObjectiveID { get => objectiveID; set => objectiveID = value; }
            /// <summary>
            /// Feature ID.
            /// </summary>
            public byte PointType { get => pointType; set => pointType = value; }
            /// <summary>
            /// Number of Points this Objective has.
            /// </summary>
            public ushort PointCount { get => pointCount; set => pointCount = value; }
            /// <summary>
            /// The Point Index in the Point Table where this set of Objective Points begins.
            /// </summary>
            public ushort FirstPoint { get => originalFirstPoint; set => originalFirstPoint = value; }
            /// <summary>
            /// A Value that can be used to represent various specific fields, typically the Runway Heading.
            /// </summary>
            public double DataValue { get => dataValue; set => dataValue = value; }
            /// <summary>
            /// Texture used for this Point.
            /// </summary>
            public short RunwayTexture { get => runwayTexture; set => runwayTexture = value; }
            /// <summary>
            /// Runway Number this Point is part of.
            /// </summary>
            public short RunwayNumber { get => runwayNumber; set => runwayNumber = value; }
            /// <summary>
            /// Landing Pattern this Point is part of.
            /// </summary>
            public LandingPattern LandingPattern { get => landingPattern; set => landingPattern = value; }
            /// <summary>
            /// External Features required to be loaded for this Point.
            /// </summary>
            public Collection<byte> Dependencies
            {
                get => dependencies;
                set
                {
                    while (value.Count > 16) value.RemoveAt(16);
                    dependencies = value;
                }
            }

            #endregion Properties

            #region Fields
            private int iD = 0;
            private short objectiveID = 0;
            private byte pointType = 0;
            private ushort pointCount = 0;
            private ushort originalFirstPoint = 0;
            private double dataValue = 0;
            private Collection<byte> dependencies = [];
            private short runwayTexture = -1;
            private short runwayNumber = -1;
            private LandingPattern landingPattern = LandingPattern.None;
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
                sb.AppendLine("   ID: " + ID);
                sb.AppendLine("   Objective ID: " + ObjectiveID);
                sb.AppendLine("   Point Type: " + PointType);
                sb.AppendLine("   Point Count: " + PointCount);
                sb.AppendLine("   Variable Data: " + dataValue);
                sb.AppendLine("   First Point: " + FirstPoint);
                sb.AppendLine("   Runway Texture: " + RunwayTexture);
                sb.AppendLine("   Runway Number: " + RunwayNumber);
                sb.AppendLine("   Landing Pattern: " + LandingPattern);
                for (int i = 0; i < Dependencies.Count; i++)
                    sb.AppendLine("   Dependency " + i + ": " + dependencies[i]);

                return sb.ToString();
            }
            /// <summary>
            /// Formats the <see cref="PointHeaderData"/> as a <see cref="DataRow"/>.
            /// </summary>
            /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
            public DataRow ToDataRow()
            {
                string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\PHD.xsd");
                if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

                DataSet dataSet = new();
                dataSet.ReadXmlSchema(schemaFile);
                DataTable table = dataSet.Tables[0];
                DataRow row = table.NewRow();

                row["Num"] = ID;
                row["ObjIdx"] = ObjectiveID;
                row["Type"] = PointType;
                row["PointCount"] = PointCount;
                row["Data"] = DataValue;
                row["FirstPtIdx"] = FirstPoint;
                row["RunwayTexture"] = RunwayTexture;
                row["RunwayNumber"] = RunwayNumber;
                row["LandingPattern"] = (short)LandingPattern;
                

                for (int i = 0; i < Dependencies.Count; i++)
                {
                    if (Dependencies[i] != 255)
                        row["FeatureDependencyIdx_" + i] = dependencies[i];
                    else
                        row["FeatureDependencyIdx_" + i] = DBNull.Value;
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
                hash.Add(objectiveID);
                hash.Add(pointType);
                hash.Add(pointCount);
                hash.Add(originalFirstPoint);
                hash.Add(dataValue);
                hash.Add(dependencies);
                hash.Add(runwayTexture);
                hash.Add(runwayNumber);
                hash.Add(landingPattern);
                return hash.ToHashCode();
            }

            #endregion Funcitnoal Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="PointHeaderData"/> object.
            /// </summary>
            public PointHeaderData()
            {
                for (int i = 0; i < 16; i++)
                    Dependencies.Add(255);
            }
            /// <summary>
            /// Initializes an instance of the <see cref="PointHeaderData"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
            /// </summary>
            /// <param name="row"></param>
            public PointHeaderData(DataRow row)
                : this()
            {
                string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\PHD.xsd");
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
                    ObjectiveID = (short)row["ObjIdx"];
                    PointType = (byte)row["Type"];
                    PointCount = (ushort)row["PointCount"];
                    if (row["Data"] != DBNull.Value)
                        DataValue = (float)row["Data"];
                    FirstPoint = (ushort)row["FirstPtIdx"];
                    if (row["RunwayTexture"] != DBNull.Value)
                        RunwayTexture = (short)row["RunwayTexture"];
                    if (row["RunwayNumber"] != DBNull.Value)
                        RunwayNumber = (short)row["RunwayNumber"];
                    if (row["LandingPattern"] != DBNull.Value)
                        LandingPattern = (LandingPattern)(short)row["LandingPattern"];

                    for (int i = 0; i < Dependencies.Count; i++)
                    {
                        if (row["FeatureDependencyIdx_" + i] != DBNull.Value)
                            dependencies[i] = (byte)row["FeatureDependencyIdx_" + i];
                    }
                }
                catch (Exception ex)
                {
                    Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a PHD Entry.");
                    throw;
                }
            }
            #endregion Constructors     
        }

        #endregion Subclasses
    }
}
