using Mantle.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts
{
    public interface IEffectClassLoot
    {
        Task<EffectClass> GetByIdAsync(int id);
        Task<IEnumerable<EffectClass>> GetAllAsync();
    }
}
