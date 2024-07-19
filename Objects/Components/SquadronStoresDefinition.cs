using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Squadron Stores Definition in the Database.
    /// </summary>
    public class SquadronStoresDefinition
    {
        #region Properties
        /// <summary>
        /// Weapon Stores for a Squadron. Key = WeaponID, Value = Count.
        /// </summary>
        public Dictionary<int, int?> Stores { get => stores; set => stores = value; }
        /// <summary>
        /// An A-G Weapon ID that never runs out.
        /// </summary>
        public byte InfiniteAG { get => infiniteAG; set => infiniteAG = value; }
        /// <summary>
        /// An A-A Weapon ID that never runs out.
        /// </summary>
        public byte InfiniteAA { get => infiniteAA; set => infiniteAA = value; }
        /// <summary>
        /// A Gun Weapon ID that never runs out.
        /// </summary>
        public byte InfiniteGun { get => infiniteGun; set => infiniteGun = value; }
        #endregion Properties

        #region Fields
        private Dictionary<int, int?> stores = [];	// Weapon stores (only has meaning for squadrons)
        private byte infiniteAG;					            // One AG weapon we've chosen to always have available
        private byte infiniteAA;					            // One AA weapon we've chosen to always have available
        private byte infiniteGun;                               // Our main gun weapon, which we will always have available


        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stores.Count; i++)
                if (stores[i] is not null && stores[i] > 0)
                    sb.AppendLine("Weapon ID: " + i + ": " + stores[i]);
            sb.AppendLine("Infinite A-G Weapon ID: " + infiniteAG);
            sb.AppendLine("Infinite A-A Weapon ID: " + infiniteAA);
            sb.AppendLine("Infinite Gun Weapon ID: " + infiniteGun);
            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="SquadronStoresDefinition"/> object.
        /// </summary>
        public SquadronStoresDefinition()
        {
        }
        #endregion Constructors     

    }
}
