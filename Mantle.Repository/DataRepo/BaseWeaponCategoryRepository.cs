using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantle.Repository.DataRepo
{
    public class BaseWeaponCategoryRepository : BaseRepository<BaseWeaponCategory, MantleDbContext>, IBaseWeaponCategoryRepository
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
                join bd in _dbContext.BaseDice on bwc.BaseDiceId equals bd.Id
                select new BaseWeaponCategory
                {
                    Id = bwc.Id,
                    WeaponCategory = bwc.WeaponCategory,
                    BaseDamageTypeId = bwc.BaseDamageTypeId,
                    BaseDamageType = bdt,
                    Weight = bwc.Weight,
                    Cost = bwc.Cost,
                    BaseDiceId = bwc.BaseDiceId,
                    BaseDice = bd,
                    IsMartial = bwc.IsMartial,
                    IsRange = bwc.IsRange,
                    ModifiedBy = bwc.ModifiedBy,
                    ModifiedOn = bwc.ModifiedOn
                }).AsNoTracking();

            return await data.ToListAsync();
        }

        public new async Task<BaseWeaponCategory> GetByIdAsync(int id)
        {
            var data = (
                from bwc in _dbContext.BaseWeaponCategory
                join bdt in _dbContext.BaseDamageType on bwc.BaseDamageTypeId equals bdt.Id
                join bd in _dbContext.BaseDice on bwc.BaseDiceId equals bd.Id
                where bwc.Id == id
                select new BaseWeaponCategory
                {
                    Id = bwc.Id,
                    WeaponCategory = bwc.WeaponCategory,
                    BaseDamageTypeId = bwc.BaseDamageTypeId,
                    BaseDamageType = bdt,
                    Weight = bwc.Weight,
                    Cost = bwc.Cost,
                    BaseDiceId = bwc.BaseDiceId,
                    BaseDice = bd,
                    IsMartial = bwc.IsMartial,
                    IsRange = bwc.IsRange,
                    ModifiedBy = bwc.ModifiedBy,
                    ModifiedOn = bwc.ModifiedOn
                });

            return await data.SingleOrDefaultAsync();
        }
    }
}
