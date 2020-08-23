using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
            var data = await _baseWeaponCategoryRepository.GetAllQueryReadOnlyAsync();
            var baseData = await _baseWeaponCategoryRepository.GetAllReadOnlyAsync();

            return baseData;
        }

        public async Task<BaseWeaponCategory> GetByIdAsync(int id)
        {
            return await _baseWeaponCategoryRepository.GetByIdReadOnlyAsync(id);
        }
    }
}
