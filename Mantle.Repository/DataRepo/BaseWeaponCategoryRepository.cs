using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Mantle.Repository.DataRepo
{
    public class BaseWeaponCategoryRepository<T> : BaseRepository<BaseWeaponCategory>, IBaseWeaponCategoryRepository<BaseWeaponCategory>
    {
        MantleDbContext _dbContext;

        public BaseWeaponCategoryRepository(MantleDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public new async Task<IEnumerable<BaseWeaponCategory>> GetAllReadOnlyAsync()
        {
            var data = (
                from bwc in _dbContext.BaseWeaponCategory
                join bdt in _dbContext.BaseDamageType on bwc.BaseDamageTypeId equals bdt.Id
                select new BaseWeaponCategory
                {
                    Id = bwc.Id,
                    WeaponCategory = bwc.WeaponCategory,
                    BaseDamageType = bdt,
                    Weight = bwc.Weight,
                    Cost = bwc.Cost,
                    BaseDiceId = bwc.BaseDiceId,
                    IsMartial = bwc.IsMartial,
                    IsRange = bwc.IsRange,
                    BaseDamageTypeId = bwc.BaseDamageTypeId,
                    ModifiedBy = bwc.ModifiedBy,
                    ModifiedOn = bwc.ModifiedOn
                }).AsNoTracking();

            return await Task.FromResult(data.ToList());
        }
    }
}
