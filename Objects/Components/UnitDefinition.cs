using FalconDatabase.Enums;
using System.Collections.ObjectModel;
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
        /// ID in the Database.
        /// </summary>
        public short ID { get => index; set => index = value; }
        /// <summary>
        /// Number of Vehicles in each Element.
        /// </summary>
        public Dictionary<int, int> NumElements { get => numElements; set => numElements = value; }
        /// <summary>
        /// Type of Vehicle in each Element.
        /// </summary>
        public Dictionary<int, short> VehicleType { get => vehicleType; set => vehicleType = value; }
        /// <summary>
        /// Vehicle Flags for each Element.
        /// </summary>
        public Dictionary<int, ushort> ElementFlags { get => elementFlags; set => elementFlags = value; }
        /// <summary>
        /// Unit Flags.
        /// </summary>
        public ushort Flags { get => flags; set => flags = value; }
        /// <summary>
        /// Unit Name.
        /// </summary>
        public string Name { get => name; set => name = value; }
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
        /// Mission Type Score Value.
        /// </summary>
        public Collection<byte> Scores { get => scores; set => scores = value; }
        /// <summary>
        /// Primary Mission Type Score.
        /// </summary>
        public byte Role { get => role; set => role = value; }
        /// <summary>
        /// Hit Chance against Targets with a given Movement Type.
        /// </summary>
        public Collection<byte> HitChance { get => hitChance; set => hitChance = value; }
        /// <summary>
        /// Hit Chance against Targets with a given Movement Type.
        /// </summary>
        public Collection<byte> Strength { get => strength; set => strength = value; }
        /// <summary>
        /// Range against Targets with a given Movement Type.
        /// </summary>
        public Collection<byte> Range { get => range; set => range = value; }
        /// <summary>
        /// Detection against Targets with a given Movement Type.
        /// </summary>
        public Collection<float> Detection { get => detection; set => detection = value; }
        /// <summary>
        /// Damage Modifier against Targets with a given Movement Type.
        /// </summary>
        public Collection<byte> DamageMod { get => damageMod; set => damageMod = value; }
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
        #endregion Properties

        #region Fields
        private short index;
        private Dictionary<int, int> numElements = [];
        private Dictionary<int, short> vehicleType = [];
        private Dictionary<int, ushort> elementFlags = [];
        private ushort flags = 0;
        private string name = "";
        private MoveType movementType = MoveType.NoMove;
        private short movementSpeed = 0;
        private short maxRange = 0;
        private int fuel = 0;
        private short rate = 0;
        private short ptDataIndex = 0;
        private Collection<byte> scores = [];
        private byte role = 0;
        private Collection<byte> hitChance = [];
        private Collection<byte> strength = [];
        private Collection<byte> range = [];
        private Collection<float> detection = [];
        private Collection<byte> damageMod = [];
        private short radarVehicle = 0;
        private short specialIndex = 0;
        private short iconIndex = 0;
        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Unit ID: " + index);
            sb.AppendLine("Elements: ");
            for (int i = 0; i < NumElements.Count; i++)
            {
                sb.AppendLine("Element " + i + ": ");
                sb.AppendLine("   Vehicle Type: " + VehicleType[i]);
                sb.AppendLine("   Vehicle Count: " + NumElements[i]);
                if (ElementFlags[i] != 0)
                    sb.AppendLine("   Flags: " + ElementFlags[i]);
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
            sb.AppendLine("Primary Role: " + Role);
            sb.AppendLine("Statistics by Enemy Movement Type: ");
            for (int i = 0; i < HitChance.Count; i++)
            {
                sb.AppendLine("   Movement Type " + i + ":");
                sb.AppendLine("     Hit Chance: " + HitChance[i]);
                sb.AppendLine("     Strength: " + Strength[i]);
                sb.AppendLine("     Range: " + Range[i]);
                sb.AppendLine("     Detection: " + Detection[i]);
            }
            sb.AppendLine("Damage Modifiers by Damage Type: ");
            for (int i = 0; i < DamageMod.Count; i++)
                sb.AppendLine("   " + "Damage Type " + i + ": " + damageMod[i]);
            sb.AppendLine("Radar Vehicle Type: " + RadarVehicle);
            sb.AppendLine("Special Index: " + SquadronStoresID);
            sb.AppendLine("Icon Index: " + IconIndex);

            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="UnitDefinition"/> object.
        /// </summary>
        public UnitDefinition()
        {
        }
        #endregion Constructors     

    }
}
