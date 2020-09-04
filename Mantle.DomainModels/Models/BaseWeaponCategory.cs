using System;

namespace Mantle.DomainModels.Models
{
    public class BaseWeaponCategory
    {
        public int Id { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public string WeaponCategory { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public bool IsMartial { get; set; }
        public bool IsRange { get; set; }

        public int BaseDamageTypeId { get; set; }
        public int BaseDiceId { get; set; }

        public string BaseDamageType { get; set; }
        public string BaseDice { get; set; }
    }
}
