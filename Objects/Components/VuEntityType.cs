using System.Collections.ObjectModel;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Entity Type Class Definition.
    /// </summary>
    public class VuEntityType
    {
        #region Properties
        /// <summary>
        /// Entity Type ID.
        /// </summary>
        public ushort ID { get => id; set => id = value; }
        /// <summary>
        /// Collision Type.
        /// </summary>
        public ushort CollisionType { get => collisionType; set => collisionType = value; } // TODO: Enum?
        /// <summary>
        /// Collision Radius.
        /// </summary>
        public float CollisionRadius { get => collisionRadius; set => collisionRadius = value; }
        /// <summary>
        /// Collection of Class Info values.
        /// </summary>
        public Collection<byte> ClassInfo { get => classInfo; set => classInfo = value; }
        /// <summary>
        /// Rate this Entity updates the Rendering Engine.
        /// </summary>
        public uint UpdateRate { get => updateRate; set => updateRate = value; }
        /// <summary>
        /// Tolerance for skipped draw calls to the Rendering Engine.
        /// </summary>
        public uint UpdateTolerance { get => updateTolerance; set => updateTolerance = value; }
        /// <summary>
        /// Range which this Entity generates a 3D Update Bubble.
        /// </summary>
        public float FineUpdateRange { get => fineUpdateRange; set => fineUpdateRange = value; }
        /// <summary>
        /// Range at which this Entity forces an update within the Render Engine.
        /// </summary>
        public float FineUpdateForceRange { get => fineUpdateForceRange; set => fineUpdateForceRange = value; }
        /// <summary>
        /// Multiplier used by the Render Engine. Should not be adjusted externally.
        /// </summary>
        public float FineUpdateMultiplier { get => fineUpdateMultiplier; set => fineUpdateMultiplier = value; }
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
        public bool Tangible { get => tangible > 0 ? true : false; set => tangible = value == true ? (byte)1 : (byte)0; }
        /// <summary>
        /// Indicates if this Entity causes Collisions.
        /// </summary>
        public bool Collidable { get => collidable > 0 ? true : false; set => collidable = value == true ? (byte)1 : (byte)0; }
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

        private ushort id = 0;
        private ushort collisionType = 0;
        private float collisionRadius = 0;
        private Collection<byte> classInfo = [];  //init size=8;
        private uint updateRate = 0;
        private uint updateTolerance = 0;
        private float fineUpdateRange = 0;	// max distance to send position updates
        private float fineUpdateForceRange = 0; // distance to force position updates
        private float fineUpdateMultiplier = 0; // multiplier for noticing position updates
        private uint damageSeed = 0;
        private int hitpoints = 0;
        private ushort majorRevisionNumber = 0;
        private ushort minorRevisionNumber = 0;
        private ushort createPriority = 0;
        private byte managementDomain = 0;
        private byte transferable = 0;
        private byte @private = 0;
        private byte tangible = 0;
        private byte collidable = 0;
        private byte global = 0;
        private byte persistent = 0;

        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            return base.ToString();
        }
        #endregion Functional Methods

        #region Constructors
        public VuEntityType() { }

        #endregion Constructors
    }
}
