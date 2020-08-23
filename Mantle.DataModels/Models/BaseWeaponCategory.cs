using System.Collections.Generic;

namespace Mantle.DataModels.Models
{
    public class BaseWeaponCategory : BaseDataModel
    {
        public string WeaponCategory { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public bool IsMartial { get; set; }
        public bool IsRange { get; set; }

        // Foreign key
        public int BaseDamageTypeId { get; set; }
        public int BaseDiceId { get; set; }

        // Navigation property
        public virtual BaseDamageType BaseDamageType { get; set; }
        public virtual BaseDice BaseDice { get; set; }
    }
}
