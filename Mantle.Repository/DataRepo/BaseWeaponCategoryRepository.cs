using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;

namespace Mantle.Repository.DataRepo
{
    public class BaseWeaponCategoryRepository<T> : BaseRepository<BaseWeaponCategory>, IBaseWeaponCategoryRepository<BaseWeaponCategory>
    {
        public BaseWeaponCategoryRepository(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
