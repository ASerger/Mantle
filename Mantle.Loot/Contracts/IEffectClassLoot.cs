using Mantle.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mantle.Loot.Contracts
{
    public interface IEffectClassLoot
    {
        EffectClass GetById(int id);
        IEnumerable<EffectClass> GetAll();
    }
}
