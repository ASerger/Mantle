using Mantle.DataModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Repository.Contracts
{
    public interface IBaseWeaponCategoryRepository : IBaseRepository<BaseWeaponCategory>
    {
        new Task<IEnumerable<BaseWeaponCategory>> GetAllReadOnlyAsync();
        new Task<BaseWeaponCategory> GetByIdAsync(int id);
    }
}
