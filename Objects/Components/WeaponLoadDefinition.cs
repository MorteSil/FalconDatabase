using System;
using System.Collections.ObjectModel;
using System.Text;

namespace FalconDatabase.Objects.Components
{
    /// <summary>
    /// Defines the types and number of Weapons that can be loaded on a Specific Rack or Hardpoint.
    /// </summary>
    public class WeaponLoadDefinition
    {
        #region Properties
        /// <summary>
        /// Rack or Hardpoint NAme.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// Type and Number of each Weapon that can be loaded on this Rack or Hardpoint.
        /// </summary>
        public Collection<Tuple<short, short>> WeaponList { get => weaponList; set => weaponList = value; }

        #endregion Properties

        #region Fields
        private string name;
        private Collection<Tuple<short, short>> weaponList;

        #endregion Fields

        #region Functional Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < weaponList.Count; i++)
                sb.AppendLine("Weapon ID: " + weaponList[i].Item1 + " - Count: " + weaponList[i].Item2);
            return sb.ToString();
        }
        #endregion Funcitnoal Methods

        #region Constructors
        /// <summary>
        /// Default Constructor for the <see cref="WeaponLoadDefinition"/> object.
        /// </summary>
        public WeaponLoadDefinition() { }


        #endregion Constructors     

    }
}
