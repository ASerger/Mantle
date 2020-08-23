using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot
{
    public class BaseWeaponCategoryLoot : IBaseWeaponCategoryLoot
    {
        private IBaseWeaponCategoryRepository<BaseWeaponCategory> _baseWeaponCategoryRepository;
        private ILogger<BaseWeaponCategoryLoot> _logger;

        public BaseWeaponCategoryLoot(IBaseWeaponCategoryRepository<BaseWeaponCategory> baseWeaponCategoryRepo,
            ILogger<BaseWeaponCategoryLoot> logger)
        {
            _baseWeaponCategoryRepository = baseWeaponCategoryRepo;
            _logger = logger;
        }

        public async Task<IEnumerable<BaseWeaponCategory>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<BaseWeaponCategory> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
