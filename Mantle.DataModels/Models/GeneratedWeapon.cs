using System;

namespace Mantle.DataModels.Models
{
    public class GeneratedWeapon : BaseDataModel
    {
        public DateTimeOffset GeneratedOn { get; set; }

        public int BaseWeaponCategoryId { get; set; }
        public int BaseWeaponEffectId { get; set; }

        public virtual BaseWeaponCategory BaseWeaponCategory { get; set; }
        public virtual BaseWeaponEffect BaseWeaponEffect { get; set; }
    }
}
