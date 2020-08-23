using Mantle.DataModels.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantle.Repository.Contracts
{
    public interface IBaseWeaponCategoryRepository<T> : IBaseRepository<BaseWeaponCategory>
    {
        Task<IEnumerable<T>> GetAllQueryReadOnlyAsync();
    }
}
