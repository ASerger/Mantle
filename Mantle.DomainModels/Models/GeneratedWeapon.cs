using System;

namespace Mantle.DomainModels.Models
{
    public class GeneratedWeapon
    {
        public int Id { get; set; }
        public DateTimeOffset GeneratedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

        public int BaseWeaponCategoryId { get; set; }
        public int BasePropertyId { get; set; }
        public int EffectClassId { get; set; }

    }
}
