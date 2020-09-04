using Mantle.DataModels.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Repository.Contracts
{
    public interface IBaseWeaponCategoryRepository<T> : IBaseRepository<BaseWeaponCategory>
    {
        new Task<IEnumerable<T>> GetAllReadOnlyAsync();
        new Task<T> GetByIdAsync(int id);
    }
}
