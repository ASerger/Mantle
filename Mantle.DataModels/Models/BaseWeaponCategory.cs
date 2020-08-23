using System;
using System.Collections.Generic;
using System.Text;

namespace Mantle.DataModels.Models
{
    public class BaseWeaponCategory : BaseDataModel
    {
        public string WeaponCategory { get; set; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public int DamageTypeId { get; set; }
        public int BaseDiceId { get; set; }
        public bool IsMartial { get; set; }
        public bool IsRange { get; set; }
    }
}
