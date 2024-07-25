﻿using System.Data;
using System.Reflection;
using System.Text;
using System.Xml;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Radar Object Definition.
    /// </summary>
    public class RadarDefinition
    {
        #region Properties
        /// <summary>
        /// Index into the Table.
        /// </summary>
        public int ID { get => iD; set => iD = value; }
        /// <summary>
        /// Radar Name.
        /// </summary>
        public string Name { get => string.IsNullOrWhiteSpace(name) ? " " : name; set => name = value; }
        /// <summary>
        /// Sound to play when detected by an RWR.
        /// </summary>
        public int RWRSound { get => rwrsound; set => rwrsound = value; }
        /// <summary>
        /// Symbol to show when detected by an RWR.
        /// </summary>
        public short RWRSymbol { get => rwrsymbol; set => rwrsymbol = value; }
        /// <summary>
        /// Index into the RDr Data Table.
        /// </summary>
        public short RadarDataID { get => rdrDataIndex; set => rdrDataIndex = value; }
        /// <summary>
        /// Effectiveness against High Altitude Targets.
        /// </summary>
        public float HighAltitudeLethality { get => highAltLethality; set => highAltLethality = value; }
        /// <summary>
        /// Effectiveness against Low Altitude Targets.
        /// </summary>
        public float LowAltitudeLethality { get => lowAltLethality; set => lowAltLethality = value; }
        /// <summary>
        /// Detection Range.
        /// </summary>
        public float Range { get => nominalRange; set => nominalRange = value; }
        /// <summary>
        /// Width of the Beam from Center.
        /// </summary>
        public float BeamWidth { get => beamHalfAngle; set => beamHalfAngle = value; }
        /// <summary>
        /// Max Angle of the Scan Capability from Center.
        /// </summary>
        public float ScanWidth { get => scanHalfAngle; set => scanHalfAngle = value; }
        /// <summary>
        /// Speed which the Beam Sweeps.
        /// </summary>
        public float SweepRate { get => sweepRate; set => sweepRate = value; }
        /// <summary>
        /// How long the Radar will hold a lock when the target is lost.
        /// </summary>
        public float CoastTime { get => coastTime; set => coastTime = value; }
        /// <summary>
        /// How much to degrade the Signal to Noise Ratio when in a Look-Down Scenario.
        /// </summary>
        public float LookDownPenalty { get => lookDownPenalty; set => lookDownPenalty = value; }
        /// <summary>
        /// How much to degrade the Signal to Noise Ratio when in being Jammed.
        /// </summary>
        public float JammingPenalty { get => jammingPenalty; set => jammingPenalty = value; }
        /// <summary>
        /// How much to degrade the Signal to Noise Ratio when Target Aircraft Notches.
        /// </summary>
        public float NotchPenalty { get => notchPenalty; set => notchPenalty = value; }
        /// <summary>
        /// Effective Speed Target needs to fly to cause Radar to lose tracking ability.
        /// </summary>
        public float NotchSpeed { get => notchSpeed; set => notchSpeed = value; }
        /// <summary>
        /// Base probability a Chaff will be effective.
        /// </summary>
        public float ChaffChance { get => chaffChance; set => chaffChance = value; }
        /// <summary>
        /// Radar Flags.
        /// </summary>
        public short Flags { get => flag; set => flag = value; }
        
        #endregion Properties

        #region Fields
        private int iD = 0;
        private string name = "";
        private int rwrsound = 0;			            // Which sound plays in the RWR
        private short rwrsymbol = 0;			            // Which symbol shows up on the RWR
        private short rdrDataIndex = 0;		            // Index into radar data files
        private float highAltLethality = 0;
        private float lowAltLethality = 0;
        private float nominalRange = 0;					// Detection range against F16 sized target
        private float beamHalfAngle = 0;					// radians (degrees in file)
        private float scanHalfAngle = 0;					// radians (degrees in file)
        private float sweepRate = 0;						// radians/sec (degrees in file)
        private float coastTime = 0;						// ms to hold lock on faded target (seconds in file)
        private float lookDownPenalty = 0;				// degrades SN ratio
        private float jammingPenalty = 0;			    // degrades SN ratio
        private float notchPenalty = 0;					// degrades SN ratio
        private float notchSpeed = 0;					// ft/sec (kts in file)
        private float chaffChance = 0;					// Base probability a bundle of chaff will decoy this radar
        private short flag = 0;                          // 0x01 = NCTR capable

        #endregion Fields

        #region Helper Methods
        internal void Write(Stream stream)
        {
            using XmlWriter writer = XmlWriter.Create(stream);
            writer.WriteStartElement("RCD");
            writer.WriteAttributeString("Num", ID.ToString());
            {
                writer.WriteElementString("Name", Name);
                writer.WriteElementString("RwrSound", RWRSound.ToString());
                writer.WriteElementString("RwrSymbol", RWRSymbol.ToString());
                writer.WriteElementString("RadarDatIdx", RadarDataID.ToString());
                writer.WriteElementString("HighAltLethality", HighAltitudeLethality.ToString());
                writer.WriteElementString("LowAltitudeLethality", LowAltitudeLethality.ToString());
                writer.WriteElementString("DetectionRange", Range.ToString());
                writer.WriteElementString("BeamWidth", BeamWidth.ToString());
                writer.WriteElementString("ScanWidth", ScanWidth.ToString());
                writer.WriteElementString("SweepRate", SweepRate.ToString());
                writer.WriteElementString("CoastTime", CoastTime.ToString());
                writer.WriteElementString("LookDownPenalty", lookDownPenalty.ToString());
                writer.WriteElementString("JammingPenalty", JammingPenalty.ToString());
                writer.WriteElementString("NotchPenalty", NotchPenalty.ToString());
                writer.WriteElementString("NotchSpeed", notchSpeed.ToString());
                writer.WriteElementString("ChaffChance", ChaffChance.ToString());
                writer.WriteElementString("Flags", Flags.ToString());
            }
            writer.WriteEndElement();
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ID: " + iD);
            sb.AppendLine("Name: " + name);
            sb.AppendLine("RWR Sound ID: " + rwrsound);
            sb.AppendLine("RWR Symbol ID: " + rwrsymbol);
            sb.AppendLine("Radar Data Index ID: " + RadarDataID);
            sb.AppendLine("High Altitude Lethality: " + highAltLethality);
            sb.AppendLine("Low Altitude Lethality: " + LowAltitudeLethality);
            sb.AppendLine("Range: " + nominalRange);
            sb.AppendLine("Beam Angle: " + beamHalfAngle);
            sb.AppendLine("Scan Angle: " + scanHalfAngle);
            sb.AppendLine("Sweep Rate: " + sweepRate);
            sb.AppendLine("Coast Time: " + coastTime);
            sb.AppendLine("Look-Down Penalty: " + lookDownPenalty);
            sb.AppendLine("Jamming Penalty: " + jammingPenalty);
            sb.AppendLine("Notch Penalty: " + notchPenalty);
            sb.AppendLine("Notch Speed: " + notchSpeed);
            sb.AppendLine("Chaff Chance: " + chaffChance);
            sb.AppendLine("Flags: " + flag);

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="RadarDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the ACD.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\RCD.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Name"] = Name;
            row["RwrSound"] = RWRSound;
            row["RwrSymbol"] = RWRSymbol;
            row["RadarDatIdx"] = RadarDataID;
            row["HighAltLethality"] = HighAltitudeLethality;
            row["LowAltLethality"] = LowAltitudeLethality;
            row["DetectionRange"] = Range;
            row["BeamWidth"] = BeamWidth;
            row["ScanWidth"] = ScanWidth;
            row["SweepRate"] = SweepRate;
            row["CoastTime"] = CoastTime;
            row["LookDownPenalty"] = LookDownPenalty;
            row["JammingPenalty"] = JammingPenalty;
            row["NotchPenalty"] = NotchPenalty;
            row["NotchSpeed"] = NotchSpeed;
            row["ChaffChance"] = ChaffChance;
            row["Flags"] = Flags;

            return row;
        }
        
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RadarDefinition"/> object.
        /// </summary>
        public RadarDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="RadarDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public RadarDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\RCD.xsd");
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
                Name = (string)row["Name"];
                RWRSound = (int)row["RwrSound"];
                RWRSymbol = (short)row["RwrSymbol"];
                RadarDataID = (short)row["RadarDatIdx"];
                HighAltitudeLethality = (float)row["HighAltLethality"];
                LowAltitudeLethality = (float)row["LowAltLethality"];
                Range = (float)row["DetectionRange"];
                BeamWidth = (float)row["BeamWidth"];
                ScanWidth = (float)row["ScanWidth"];
                SweepRate = (float)row["SweepRate"];
                CoastTime = (float)row["CoastTime"];
                LookDownPenalty = (float)row["LookDownPenalty"];
                JammingPenalty = (float)row["JammingPenalty"];
                NotchPenalty = (float)row["NotchPenalty"];
                NotchSpeed = (float)row["NotchSpeed"];
                ChaffChance = (float)row["ChaffChance"];
                Flags = (short)row["Flags"];
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading an RCD Entry.");
                throw;
            }
        }
        #endregion Constructors     
    }
}
