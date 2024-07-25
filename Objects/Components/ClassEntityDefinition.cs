using FalconDatabase.Enums;
using System.Data;
using System.Reflection;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Entity Class Type Entry in the Database Class Table.
    /// </summary>
    public class ClassEntityDefinition
    {
        #region Properties   
        /// <summary>
        /// ID of this Class Table Entry.
        /// </summary>        
        public int ID { get => iD; set => iD = value; }        
        /// <summary>
        /// Contains Hierarchy Data for the Class Definition.
        /// </summary>
        public ClassDataDefinition ClassData { get => classData; set => classData = value; }
        /// <summary>
        /// Defines the Update Data for the Campaign and Graphics Engine.
        /// </summary>
        public ClassGraphicsUpdateDefinition UpdateData { get => updateData; set => updateData = value; }
        /// <summary>
        /// Contains data about the Visual aspects of the Class Entity.
        /// </summary>
        public ClassVisualEntityDefinition EntityData { get => entityData; set => entityData = value; }
        /// <summary>
        /// Contains the Texture Data for this Object in various states in the 3D World.
        /// </summary>
        public ClassGraphicsDefinition Textures { get => textures; set => textures = value; }
        /// <summary>
        /// Contains Data about references to external tables or files for this Entity.
        /// </summary>
        public ClassExternalDataDefinition ExternalData { get => externalData; set => externalData = value; }
        #endregion Properties

        #region Fields
        private int iD = 0;
        private int graphicsID = 60395;
        private ClassCollisionData collisionData = new(); // Unusued, do not expose with Property
        private ClassDataDefinition classData = new();
        private ClassGraphicsUpdateDefinition updateData = new();
        private ClassVisualEntityDefinition entityData = new();
        private ClassGraphicsDefinition textures = new();
        private ClassExternalDataDefinition externalData = new();
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
            StringBuilder sb = new ();
            sb.AppendLine("***** Class Data *****");
            sb.Append(this.ClassData.ToString());
            sb.AppendLine("***** Graphics Update Data *****");
            sb.Append(this.UpdateData.ToString());
            sb.AppendLine("***** Entity Visual Data *****");
            sb.Append(this.EntityData.ToString());
            sb.AppendLine("***** Texture Data *****");
            sb.Append(this.Textures.ToString());
            sb.AppendLine("***** External Reference Data *****");
            sb.Append(this.ExternalData.ToString());

            return sb.ToString();
        }
        /// <summary>
        /// Formats the <see cref="ClassEntityDefinition"/> as a <see cref="DataRow"/>.
        /// </summary>
        /// <returns><see cref="DataRow"/> object conforming to the CT.xsd Schema in the XMLSchemas Directory.</returns>
        public DataRow ToDataRow()
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\CT.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new();            
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            DataRow row = table.NewRow();

            row["Num"] = ID;
            row["Id"] = graphicsID;
            row["CollisionType"] = collisionData.CollisionType;
            row["CollisionRadius"] = collisionData.CollisionRadius;
            row["Domain"] = classData.Domain;
            row["Class"] = classData.Class;
            row["Type"] = classData.Type;
            row["SubType"] = classData.SubType;
            row["Specific"] = classData.SpecificType;
            row["Class_6"] = classData.Class_6;
            row["Class_7"] = classData.Class_7;
            row["UpdateRate"] = updateData.UpdateRate;
            row["UpdateTolerance"] = updateData.UpdateTolerance;
            row["FineUpdateRange"] = updateData.FineUpdateRange;
            row["FineUpdateForceRange"] = updateData.FineUpdateForceRange;
            row["FineUpdateMultiplier"] = updateData.FineUpdateMultiplier;
            row["DamageSeed"] = EntityData.DamageSeed;
            row["HitPoints"] = entityData.Hitpoints;
            row["MajorRev"] = entityData.MajorRevisionNumber;
            row["MinRev"] = entityData.MinorRevisionNumber;
            row["CreatePriority"] = entityData.CreatePriority;
            row["ManagementDomain"] = entityData.ManagementDomain;
            row["Transferable"] = Convert.ToByte(entityData.Transferable);
            row["Private"] = Convert.ToByte(entityData.Private);
            row["Tangible"] = Convert.ToByte(entityData.Tangible);
            row["Collidable"] = Convert.ToByte(entityData.Collidable);
            row["Global"] = Convert.ToByte(entityData.Global);
            row["Persistent"] = Convert.ToByte(entityData.Persistent);
            row["GraphicsNormal"] = textures.Normal;
            row["GraphicsRepaired"] = textures.Repaired;
            row["GraphicsDamaged"] = textures.Damaged;
            row["GraphicsDestroyed"] = textures.Destroyed;
            row["GraphicsLeftDestroyed"] = textures.LeftDestroyed;
            row["GraphicsRightDestroyed"] = textures.RightDestroyed;
            row["GraphicsBothDestroyed"] = textures.BothDestroyed;
            row["MoverDefinitionData"] = externalData.MoverData;
            row["EntityType"] = externalData.EntityClassType;
            row["EntityIdx"] = externalData.ClassTypeTableID;

            return row;
        }
        #endregion Funcitonal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="ClassEntityDefinition"/> object.
        /// </summary>
        public ClassEntityDefinition() { }
        /// <summary>
        /// Initializes an instance of the <see cref="ClassEntityDefinition"/> object with a <see cref="DataRow"/> that conforms to the ACD.xsd Schema File.
        /// </summary>
        /// <param name="row"></param>
        public ClassEntityDefinition(DataRow row)
        {
            string schemaFile = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"XMLSchemas\CT.xsd");
            if (!File.Exists(schemaFile)) throw new FileNotFoundException("Missing Schema Definition: " + schemaFile);

            DataSet dataSet = new ();
            dataSet.ReadXmlSchema(schemaFile);
            DataTable table = dataSet.Tables[0];
            try
            {
                // Verify row conforms to Schema
                table.Rows.Add(row.ItemArray);

                ID = (int)row["Num"];
                collisionData.CollisionType = (ushort)row["CollisionType"];
                collisionData.CollisionRadius = (float)row["CollisionRadius"];
                classData.Domain = (ClasstableDomain)row["Domain"];
                classData.Class = (ClasstableClass)row["Class"];
                classData.Type = (int)row["Type"];
                classData.SubType = (int)row["SubType"];
                classData.SpecificType =(int)row["Specific"];
                classData.Class_6 = (int)row["Class_6"];
                classData.Class_7 = (int)row["Class_7"];
                updateData.UpdateRate = (int)row["UpdateRate"];
                updateData.UpdateTolerance = (int)row["UpdateTolerance"];
                updateData.FineUpdateRange = (float)row["FineUpdateRange"];
                updateData.FineUpdateForceRange = (float)row["FineUpdateForceRange"];
                updateData.FineUpdateMultiplier = (float)row["FineUpdateMultiplier"];
                EntityData.DamageSeed = (uint)row["DamageSeed"];
                entityData.Hitpoints = (int)row["HitPoints"];
                entityData.MajorRevisionNumber = (ushort)row["MajorRev"];
                entityData.MinorRevisionNumber = (ushort)row["MinRev"];
                entityData.CreatePriority = (ushort)row["CreatePriority"];
                entityData.ManagementDomain = (byte)row["ManagementDomain"];
                entityData.Transferable = Convert.ToBoolean(row["Transferable"]);
                entityData.Private = Convert.ToBoolean(row["Private"]);
                entityData.Tangible = Convert.ToBoolean(row["Tangible"]);
                entityData.Collidable = Convert.ToBoolean(row["Collidable"]);
                entityData.Global = Convert.ToBoolean(row["Global"]);
                entityData.Persistent = Convert.ToBoolean(row["Persistent"]);
                textures.Normal = (int)row["GraphicsNormal"];
                textures.Repaired = (int)row["GraphicsRepaired"];
                textures.Damaged = (int)row["GraphicsDamaged"];
                textures.Destroyed = (int)row["GraphicsDestroyed"];
                textures.LeftDestroyed = (int)row["GraphicsLeftDestroyed"];
                textures.RightDestroyed = (int)row["GraphicsRightDestroyed"];
                textures.BothDestroyed = (int)row["GraphicsBothDestroyed"];
                externalData.MoverData = (int)row["MoverDefinitionData"];
                externalData.EntityClassType = (int)row["EntityType"];
                externalData.ClassTypeTableID = (int)row["EntityIdx"];
            }
            catch (Exception ex)
            {
                Utilities.Logging.ErrorLog.CreateLogFile(ex, "This Error occurred while reading a CT Entry.");
                throw;
            }
        }
        #endregion Constructors

        #region Subclasses
        /// <summary>
        /// Collision Type Data--Unused but still stored in the Data Files
        /// </summary>
        internal class ClassCollisionData
        {
            /// <summary>
            /// Collision Type.
            /// </summary>
            internal ushort CollisionType { get; set; } = 0; // Not used
            /// <summary>
            /// Collision Radius.
            /// </summary>
            internal float CollisionRadius { get; set; } = 0; // Not used           
            internal ClassCollisionData() { }
        }

        /// <summary>
        /// Database Class Hierarchy
        /// </summary>
        public class ClassDataDefinition
        {
            #region Properties
            /// <summary>
            /// The Domain of this Database Object.
            /// </summary>
            public ClasstableDomain Domain { get => domain; set => domain = value; }
            /// <summary>
            /// The Class of this Database Object.
            /// </summary>
            public ClasstableClass Class { get => @class; set => @class = value; }
            /// <summary>
            /// The Type of this Database Object.
            /// </summary>
            public int Type { get => type; set => type = value; }
            /// <summary>
            /// The SubType of this Database Object.
            /// </summary>
            public int SubType { get => subType; set => subType = value; }
            /// <summary>
            /// The Specific Type of this Database Object.
            /// </summary>
            public int SpecificType { get => specificType; set => specificType = value; }
            /// <summary>
            /// The Team that Owns this Object.
            /// </summary>
            public ModeType Owner { get => owner; set => owner = value; }
            /// <summary>
            /// Unused Placeholder.
            /// </summary>
            public int Class_6 { get => class_6; set => class_6 = value; }
            /// <summary>
            /// Unusued Placeholder.
            /// </summary>
            public int Class_7 { get => class_7; set => class_7 = value; }
            #endregion Properties

            #region Fields
            private ClasstableDomain domain = 0;
            private ClasstableClass @class = 0;
            private int type = 0;
            private int subType = 0;
            private int specificType = 0;
            private ModeType owner = 0;
            private int class_6 = 255;
            private int class_7 = 255;
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
                sb.AppendLine("Domain: " + Domain);
                sb.AppendLine("Class: " + Class);
                sb.AppendLine("Type: " + Type);
                sb.AppendLine("Sub-Type: " + SubType);
                sb.AppendLine("Specific: " + SpecificType);
                sb.AppendLine("Owner: " + Owner);

                return sb.ToString();
            }

            
            #endregion Functional Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="ClassDataDefinition"/> object.
            /// </summary>
            public ClassDataDefinition() { }

            #endregion Constructors

        }

        /// <summary>
        /// Contains data about the Textures used for various states of an object in the 3D World.
        /// </summary>
        public class ClassGraphicsDefinition
        {
            #region Properties
            /// <summary>
            /// Default Texture used for an object.
            /// </summary>
            public int Normal { get => normal; set => normal = value; }
            /// <summary>
            /// Texture used for a Repaired Object.
            /// </summary>
            public int Repaired { get => repaired; set => repaired = value; }
            /// <summary>
            /// Texture used for a Damaged Object.
            /// </summary>
            public int Damaged { get => damaged; set => damaged = value; }
            /// <summary>
            /// Texture used when an Object is completely Destroyed.
            /// </summary>
            public int Destroyed { get => destroyed; set => destroyed = value; }
            /// <summary>
            /// Texture used when an Object is partially destroyed on the Left Side.
            /// </summary>
            public int LeftDestroyed { get => leftDestroyed; set => leftDestroyed = value; }
            /// <summary>
            /// Texture used when an Object is partially destroyed on the Right Side.
            /// </summary>
            public int RightDestroyed { get => rightDestroyed; set => rightDestroyed = value; }
            /// <summary>
            /// Texture used when an Object is Destroyed on Multiple Sides but not completely Destroyed.
            /// </summary>
            public int BothDestroyed { get => bothDestroyed; set => bothDestroyed = value; }
            #endregion Properties

            #region Fields
            private int normal = 0;
            private int repaired = 0;
            private int damaged = 0;
            private int destroyed = 0;
            private int leftDestroyed = 0;
            private int rightDestroyed = 0;
            private int bothDestroyed = 0;
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
                sb.AppendLine("Normal Texture: " + Normal);
                sb.AppendLine("Repaired Texture: " + Repaired);
                sb.AppendLine("Damaged Texture: " + Damaged);
                sb.AppendLine("Destroyed Texture: " + Destroyed);
                sb.AppendLine("Left Side Destroyed Texture: " + LeftDestroyed);
                sb.AppendLine("Right Side Destroyed Texture: " + RightDestroyed);
                sb.AppendLine("Both Sides Destroyed Texture: " + bothDestroyed);
                return sb.ToString();
            }

            
            #endregion Functional Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="ClassGraphicsDefinition"/> object.
            /// </summary>
            public ClassGraphicsDefinition() { }
            #endregion Constructors
        }

        /// <summary>
        /// Contains data about the Textures used for various states of an object in the 3D World.
        /// </summary>
        public class ClassGraphicsUpdateDefinition
        {
            #region Properties
            /// <summary>
            /// Standard Time between updates for this object in the Campaign Engine.
            /// </summary>
            public int UpdateRate { get => updateRate; set => updateRate = value; }
            /// <summary>
            /// Max Time allowed between updates in the Campaign Engine when Updates are deprioritized.
            /// </summary>
            public int UpdateTolerance { get => updateTolerance; set => updateTolerance = value; }
            /// <summary>
            /// <para>Defines the 3D Bubble of the Object in feet.</para>
            /// <para>The 3D Bubbles determines when the game switches from 2D Probabalistic Execution to 3D Simulated Execution for an object.
            /// The Bubble moves with the object and everything within the Bubble will be created an added as part of the 3D Simulation.
            /// Everything within the Bubble will receive Position Updates from this Object.</para>
            /// </summary>
            public double FineUpdateRange { get => fineUpdateRange; set => fineUpdateRange = value; }
            /// <summary>
            /// Smaller Priority Bubble inside the Main bubble that forces Position Updates for other Objects.
            /// </summary>
            public double FineUpdateForceRange { get => fineUpdateForceRange; set => fineUpdateForceRange = value; }
            /// <summary>
            /// Factor by which the Update Priority is increased inside the Priority Bubble.
            /// </summary>
            public double FineUpdateMultiplier { get => fineUpdateMultiplier; set => fineUpdateMultiplier = value; }
            #endregion Properties

            #region Fields
            private int updateRate = 0;
            private int updateTolerance = 0;
            private double fineUpdateRange = 0;
            private double fineUpdateForceRange = 0;
            private double fineUpdateMultiplier = 0;


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
                sb.AppendLine("Standard Update Rate: " + updateRate);
                sb.AppendLine("Update Tolerance: " + updateTolerance);
                sb.AppendLine("Bubble Size (ft): " + fineUpdateRange);
                sb.AppendLine("Priority Bubble Size (ft): " + fineUpdateForceRange);
                sb.AppendLine("Priority Bubble Multiplier: " + fineUpdateMultiplier);
                return sb.ToString();
            }

            
            #endregion Functional Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="ClassGraphicsUpdateDefinition"/> object.
            /// </summary>
            public ClassGraphicsUpdateDefinition() { }
            #endregion Constructors
        }

        /// <summary>
        /// Contains data about External Reference Data such as Flight or Movement Model Files, or specific data information from other tables in the database.
        /// </summary>
        public class ClassExternalDataDefinition
        {
            #region Properties
            /// <summary>
            /// Reference to which Data Table within the Database this Class Table Entry is associated with.
            /// </summary>
            public int EntityClassType { get => entityClassType; set => entityClassType = value; }
            /// <summary>
            /// Index into the respective ClassTypeTable this Entity is associated with.
            /// </summary>
            public int ClassTypeTableID { get => classTypeTableID; set => classTypeTableID = value; }
            /// <summary>
            /// Contains a reference to an external file that holds Vehicle Physics and Movement Data, such as Flight Models or Ground Vehicle movement profiles.
            /// </summary>
            public string? VehicleProfileReferenceFile 
            { 
                get => vehicleProfileReferenceFile?.Name; 
                set
                {
                    if (File.Exists(value))
                        vehicleProfileReferenceFile = new FileInfo(value);
                    else vehicleProfileReferenceFile = null;
                }
            }
            /// <summary>
            /// File Index for Mover Data.
            /// </summary>
            public int MoverData { get => moverData; set => moverData = value; }
            #endregion Properties

            #region Fields
            private int entityClassType = 0;
            private int classTypeTableID = 0;
            private int moverData = 0;
            private FileInfo? vehicleProfileReferenceFile;


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
                sb.AppendLine("Entity Class Type: " + entityClassType);
                sb.AppendLine("Entity Class Table ID: " + classTypeTableID);
                sb.AppendLine("Vehicle Profile: " + vehicleProfileReferenceFile?.FullName);
                return sb.ToString();
            }

            
            #endregion Functional Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="ClassExternalDataDefinition"/> object.
            /// </summary>
            public ClassExternalDataDefinition() { }
            #endregion Constructors
        }

        /// <summary>
        /// Entity Type Class Definition.
        /// </summary>
        public class ClassVisualEntityDefinition
        {
            #region Properties           
            /// <summary>
            /// Random Seed for Damage calculations.
            /// </summary>
            public uint DamageSeed { get => damageSeed; set => damageSeed = value; }
            /// <summary>
            /// Current Health of the Entity.
            /// </summary>
            public int Hitpoints { get => hitpoints; set => hitpoints = value; }
            /// <summary>
            /// Entity Major Revision Number.
            /// </summary>
            public ushort MajorRevisionNumber { get => majorRevisionNumber; set => majorRevisionNumber = value; }
            /// <summary>
            /// Entity Minor Revision Number.
            /// </summary>
            public ushort MinorRevisionNumber { get => minorRevisionNumber; set => minorRevisionNumber = value; }
            /// <summary>
            /// Prioritization value for the Render Engine.
            /// </summary>
            public ushort CreatePriority { get => createPriority; set => createPriority = value; }
            /// <summary>
            /// Management Engine within the Campaign that handles this Entity.
            /// </summary>
            public byte ManagementDomain { get => managementDomain; set => managementDomain = value; }
            /// <summary>
            /// Indicates if this Entity can be transferred between Objects or Domains.
            /// </summary>
            public bool Transferable { get => transferable > 0 ? true : false; set => transferable = value == true ? (byte)1 : (byte)0; }
            /// <summary>
            /// Indicates if this Entity is Private.
            /// </summary>
            public bool Private { get => @private > 0 ? true : false; set => @private = value == true ? (byte)1 : (byte)0; }
            /// <summary>
            /// Indicates if this Entity is Tangible.
            /// </summary>
            public bool Tangible { get => tangible > 0; set => tangible = value == true ? (byte)1 : (byte)0; }
            /// <summary>
            /// Indicates if this Entity causes Collisions.
            /// </summary>
            public bool Collidable { get => collidable > 0 ? true : false; set => collidable = value == true ? (byte)1 : (byte)0; } // Not Used
            /// <summary>
            /// Indicates if this is a Global Object.
            /// </summary>
            public bool Global { get => global > 0 ? true : false; set => global = value == true ? (byte)1 : (byte)0; }
            /// <summary>
            /// Indicates if this is a Persistent Object.
            /// </summary>
            public bool Persistent { get => persistent > 0 ? true : false; set => persistent = value == true ? (byte)1 : (byte)0; }


            #endregion Properties

            #region Fields
            private uint damageSeed = 0;
            private int hitpoints = 0;
            private ushort majorRevisionNumber = 0;
            private ushort minorRevisionNumber = 0;
            private ushort createPriority = 0;
            private byte managementDomain = 0;
            private byte transferable = 0;
            private byte @private = 0;
            private byte tangible = 0;
            private byte collidable = 0; // Not used
            private byte global = 0;
            private byte persistent = 0;

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
                sb.AppendLine("Damage Seed: " + damageSeed);
                sb.AppendLine("Hit Points: " + hitpoints);
                sb.AppendLine("Major Revision: " + majorRevisionNumber);
                sb.AppendLine("Minor Revision: " + minorRevisionNumber);
                sb.AppendLine("Create Priority: " + createPriority);
                sb.AppendLine("Management Domain: " + managementDomain);
                sb.AppendLine("Is Transferable: " + transferable);
                sb.AppendLine("Is Private: " + Private);
                sb.AppendLine("Is Tangible: " + tangible);
                sb.AppendLine("Is Collidable: " + collidable);
                sb.AppendLine("Is Global: " + global);
                sb.AppendLine("Is Persistent: " + persistent);
                return sb.ToString();
            }

            
            #endregion Functional Methods

            #region Constructors
            /// <summary>
            /// Default Constructor for the <see cref="ClassVisualEntityDefinition"/> object.
            /// </summary>
            public ClassVisualEntityDefinition() { }

            #endregion Constructors
        }
        #endregion Subclasses
    }
}
