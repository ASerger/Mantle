using Mantle.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts
{
    public interface IWeaponClassLoot
    {
        Task<WeaponClass> GetByIdAsync(int id);
        Task<IEnumerable<WeaponClass>> GetAllAsync();
    }
}
