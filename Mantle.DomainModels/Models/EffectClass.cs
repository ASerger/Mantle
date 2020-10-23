using System;

namespace Mantle.DomainModels.Models
{
    public class EffectClass
    {
        public int Id { get; set; }
        public string EffectName { get; set; }
        public int DiceCount { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
