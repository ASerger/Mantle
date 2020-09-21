using Mantle.DomainModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts
{
    public interface IBaseWeaponCategoryLoot
    {
        Task<BaseWeaponCategory> GetByIdAsync(int id);
        Task<IEnumerable<BaseWeaponCategory>> GetAllAsync();
        Task<BaseWeaponCategory> AddRecordAsync(BaseWeaponCategory domainModel);
    }
}