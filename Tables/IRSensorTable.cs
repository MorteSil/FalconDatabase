﻿using FalconDatabase.Components;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;
using System.Xml;

namespace FalconDatabase.Tables
{
    /// <summary>
    /// The IR Sensor Database contained in the FALCON4_ICD.xml File.
    /// </summary>
    public class IRSensorTable : AppFile, IEquatable<IRSensorTable>
    {
        #region Properties
        /// <summary>
        /// Collection of <see cref="IRSensorDefinition" /> Entries exported from the Database.
        /// </summary>
        public Collection<IRSensorDefinition> IRSensors { get => dbObjects; set => dbObjects = value; }
        /// <summary>
        /// IR Sensor Component of the Database in Raw Data Format.
        /// </summary>
        public DataTable IRSensortDataTable
        {
            get
            {
                DataSet dataSet = new();
                dataSet.ReadXmlSchema(schemaFile);
                DataTable table = dataSet.Tables[0];
                foreach (var entry in dbObjects)
                {
                    table.Rows.Add(entry.ToDataRow().ItemArray);
                }
                return table;
            }
        }
        /// <summary>
        /// <para>When <see langword="true"/>, indicates this <see cref="AppFile"/> was successfully loaded from the file.</para>
        /// <para><see langword="false"/> indicates there were no values in the initialization data used for this <see cref="AppFile"/> object and empty or default values were loaded instead.</para>
        /// </summary>
        public override bool IsDefaultInitialization { get => dbObjects.Count == 0; }
        #endregion Properties

        #region Fields
        private Collection<IRSensorDefinition> dbObjects = [];
        private readonly string schemaFile =
            Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\ICD.xsd");
        #endregion Fields

        #region Helper Methods        
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
                DataSet ds = new();
                ds.ReadXmlSchema(schemaFile);
                ds.ReadXml(reader);
                foreach (DataRow row in ds.Tables[0].Rows) dbObjects.Add(new(row));
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading the ICD Table.");
                reader.Close();
                throw;
            }

            return true;
        }
        /// <summary>
        /// Formats the File Contents into bytes for writing to disk.
        /// </summary>
        /// <returns><see cref="byte"/> array suitable for writing to a file.</returns>
        protected override byte[] Write()
        {
            DataSet ds = new();
            ds.ReadXmlSchema(schemaFile);

            using MemoryStream stream = new();
            using XmlWriter writer = XmlWriter.Create(stream);
            try
            {
                foreach (var entry in dbObjects)
                    ds.Tables[0].Rows.Add(entry.ToDataRow().ItemArray);

                ds.WriteXml(writer, XmlWriteMode.IgnoreSchema);
                stream.Position = 0;
                return Encoding.UTF8.GetBytes(new StreamReader(stream).ReadToEnd());
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while writing the ICD Table.");
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
            StringBuilder sb = new();
            sb.Append("***** IR Sensor Table *****");
            foreach (var entry in dbObjects)
                sb.Append(entry.ToString());

            return sb.ToString();
        }

        #region Equality Functions
        /// <summary>
        /// Evaluates if the <paramref name="other"/> has the same data as this <see cref="object"/> using content and hash comparisons.
        /// </summary>
        /// <param name="other">An object to compare values to.</param>
        /// <returns><see langword="true"/> if the objects match, otherwise <see langword="false"/>.</returns>
        public override bool Equals(object? other)
        {
            if (other == null)
                return false;

            if (other is not IRSensorTable comparator)
                return false;
            else
                return Equals(comparator);
        }
        /// <summary>
        /// Generates a Hash Code for the object.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {

            unchecked
            {
                int hash = 2539;
                for (int i = 0; i < dbObjects.Count; i++)
                    hash = hash * 5483 + dbObjects[i].GetHashCode();
                return hash;
            }

        }
        /// <summary>
        /// Evaluates if the <paramref name="other"/> has the same data as this <see cref="object"/> using content and hash comparisons.
        /// </summary>
        /// <param name="other">An object to compare values to.</param>
        /// <returns><see langword="true"/> if the objects match, otherwise <see langword="false"/>.</returns>
        public bool Equals(IRSensorTable? other)
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
        /// Default Constructor for the <see cref="IRSensorTable"/> object.
        /// </summary>
        public IRSensorTable()
        {
            _FileType = ApplicationFileType.DatabaseICD;
            _StreamType = FileStreamType.XML;
            _IsCompressed = false;
        }
        /// <summary>
        /// Initializes an instance of the <see cref="IRSensorTable"/> component of the Database with the data contained in the file at <paramref name="filePath"/>.
        /// </summary>
        /// <param name="filePath">Path to read the data from.</param>
        public IRSensorTable(string filePath)
            : this()
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(filePath);

            if (Directory.Exists(filePath))
                Load(filePath);
            else throw new FileNotFoundException(filePath);
        }
        #endregion Constructors
    }
}
