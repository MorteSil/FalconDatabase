using FalconDatabase.Enums;
using FalconDatabase.Objects.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace FalconDatabase.Files
{
    /// <summary>
    /// The Radar Database contained in the FALCON4_RCD.xml File.
    /// </summary>
    public class RadarTable : GameFile, IEquatable<RadarTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="RadarDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<RadarDefinition> RadarDefinitions
        {
            get
            {
                Collection<RadarDefinition> output = new();
                foreach (DataRow row in dbTable.Rows)
                    output.Add(ToRadarDefinition(row));

                return output;
            }
        }
        /// <summary>
        /// Radar Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable Radars { get => dbTable; set => dbTable = value; }
        /// <summary>
        /// <para>When <see langword="true"/>, indicates this <see cref="GameFile"/> was successfully loaded from the file.</para>
        /// <para><see langword="false"/> indicates there were no values in the initialization data used for this <see cref="GameFile"/> object and empty or default values were loaded instead.</para>
        /// </summary>
        public override bool IsDefaultInitialization { get => dbTable.Rows.Count > 0; }
        #endregion Properties

        #region Fields
        private DataTable dbTable = new();
        #endregion Fields

        #region Helper Methods

        /// <summary>
        /// Converts a <see cref="DataRow"/> with correct values into a native Falcon Object.
        /// </summary>
        /// <param name="row">A <see cref="DataRow"/> with appropriate initializaiton data values.</param>
        /// <returns></returns>
        private static RadarDefinition ToRadarDefinition(DataRow row)
        {
            try
            {
                int index = 0;
                RadarDefinition output = new()
                {
                    Name = (string)row[index++],
                    RWRsound = int.Parse((string)row[index++]),
                    RWRsymbol = short.Parse((string)row[index++]),
                    ID = short.Parse((string)row[index++]),
                    Lethality = [
                        float.Parse((string)row[index++]),
                        float.Parse((string)row[index++])
                        ],
                    Range = float.Parse((string)row[index++]),
                    BeamWidth = float.Parse((string)row[index++]),
                    ScanWidth = float.Parse((string)row[index++]),
                    SweepRate = float.Parse((string)row[index++]),
                    CoastTime = float.Parse((string)row[index++]),
                    LookDownPenalty = float.Parse((string)row[index++]),
                    JammingPenalty = float.Parse((string)row[index++]),
                    NotchPenalty = float.Parse((string)row[index++]),
                    NotchSpeed = float.Parse((string)row[index++]),
                    ChaffChance = float.Parse((string)row[index++]),
                    Flags = short.Parse((string)row[index++])
                };

                return output;
            }
            catch (Exception ex)
            { return null; }

        }
        /// <summary>
        /// Processes the XML Data in <paramref name="data"/> and attempts to convert it into a <see cref="DataTable"/> with values read from <paramref name="data"/>.
        /// </summary>
        /// <param name="data">XML Data read from a Database File in the ..\TerrData\Objects\ Directory.</param>
        /// <returns><see langword="true"/> if the File is successfully read and parsed. Otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        protected override bool Read(string data)
        {
            ArgumentException.ThrowIfNullOrEmpty(data);

            using StringReader reader = new(data);
            try
            {
                // DataSet can auto configure the XML Schema
                DataSet table = new();
                table.ReadXml(reader);
                dbTable = table.Tables[0];
            }
            catch (Exception ex)
            {
                reader.Close();
                throw;
            }

            return dbTable.Rows.Count > 0;
        }
        /// <summary>
        /// Formats the File Contents into bytes for writing to disk.
        /// </summary>
        /// <returns><see cref="byte"/> array suitable for writing to a file.</returns>
        protected override byte[] Write()
        {
            using MemoryStream stream = new MemoryStream();
            try
            {
                stream.Write(Encoding.UTF8.GetBytes("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + Environment.NewLine));
                dbTable.WriteXml(stream);
                stream.Write(Encoding.UTF8.GetBytes(Environment.NewLine));
                stream.Position = 0;
                return Encoding.UTF8.GetBytes(new StreamReader(stream).ReadToEnd());
            }
            catch (Exception ex)
            {
                stream.Close();
                throw;
            }
        }

        #endregion Helper Methods

        #region Functional Methods

        /// <summary>
        /// Formats the Data in this Table for Generic Text Output.
        /// </summary>
        /// <returns><para><see cref="string"/> object with the data from this object.</para>
        /// <para>NOTE: This does not format the Database file for XML Output.</para></returns>
        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();
            foreach (DataRow row in dbTable.Rows)
            {
                sb.AppendLine("***** Radar Table Entry *****");
                sb.Append(ToRadarDefinition(row).ToString());
            }

            return sb.ToString();
        }

        #region Equality Functions
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            RadarTable? comparator = other as RadarTable;
            if (comparator is null)
                return false;
            else
                return Equals(comparator);
        }
        public override int GetHashCode()
        {

            unchecked
            {
                int hash = 2539;
                for (int i = 0; i < dbTable.Rows.Count; i++)
                    hash = hash * 5483 + dbTable.Rows[i].GetHashCode();
                return hash;
            }

        }
        public bool Equals(RadarTable? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;

            return other.ToString() == ToString() && other.GetHashCode() == GetHashCode();
        }
        #endregion Equality Functions

        #endregion Functional Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="RadarTable"/> object.
        /// </summary>
        public RadarTable()
        {
            _FileType = GameFileType.DatabaseRCD;
            _StreamType = FileStreamType.XML;
            _IsFileModified = false;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="RadarTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public RadarTable(string filePath)
            : this()
        {
            if (File.Exists(filePath))
                Load(filePath);
        }
        #endregion Constructors
    }
}
