using System.Collections.Generic;

namespace Mantle.DataModels.Models
{
    public class BaseWeaponEffect : BaseDataModel
    {
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public string EffectDescription { get; set; }
        public int BaseDiceId { get; set; }
        public int EffectClassId { get; set; }

        public virtual BaseDice BaseDice { get; set; }
        public virtual EffectClass EffectClass { get; set; }
        public ICollection<GeneratedWeapon> GeneratedWeapon { get; set; }
    }
}
