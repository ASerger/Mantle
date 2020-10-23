using System.Collections.Generic;

namespace Mantle.DataModels.Models
{
    public class EffectClass : BaseDataModel
    {
        public string EffectName { get; set; }
        public int DiceCount { get; set; }

        public ICollection<BaseWeaponEffect> BaseWeaponEffect { get; set; }
    }
}
