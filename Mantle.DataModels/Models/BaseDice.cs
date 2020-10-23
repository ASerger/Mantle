using System.Collections.Generic;

namespace Mantle.DataModels.Models
{
    public class BaseDice : BaseDataModel
    {
        public int Count { get; set; }
        public int Sides { get; set; }
        public string DiceDescription { get; set; }

        public ICollection<BaseWeaponCategory> BaseWeaponCategory { get; set; }
        public ICollection<BaseWeaponEffect> BaseWeaponEffect { get; set; }
    }
}
