using System;
using System.Collections.Generic;
using System.Text;

namespace Mantle.DataModels.Models
{
    public class WeaponClass
    {
        public int WeaponClassId { get; set; }
        public string WeaponName { get; set; }
        public string BaseDamageModifier { get; set; }
        public string DamageType { get; set; }
    }
}
