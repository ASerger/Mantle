using Mantle.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts
{
    public interface IBaseWeaponCategoryLoot
    {
        Task<BaseWeaponCategory> GetByIdAsync(int id);
        Task<IEnumerable<BaseWeaponCategory>> GetAllAsync();
    }
}