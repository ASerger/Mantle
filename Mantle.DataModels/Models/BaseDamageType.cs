using System.Collections.Generic;

namespace Mantle.DataModels.Models
{
    public class BaseDamageType : BaseDataModel
    {
        public string DamageType { get; set; }

        // Navigation Property
        public ICollection<BaseWeaponCategory> BaseWeaponCategory { get; set; }
    }
}
