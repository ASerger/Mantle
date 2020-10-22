using Domain = Mantle.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts
{
    public interface IBaseWeaponCategoryLoot
    {
        Task<Domain.BaseWeaponCategory> GetByIdAsync(int id);
        Task<IEnumerable<Domain.BaseWeaponCategory>> GetAllAsync();
    }
}