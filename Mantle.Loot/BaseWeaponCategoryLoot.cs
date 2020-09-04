using Datamodels = Mantle.DataModels.Models;
using Domainmodels = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Loot
{
    public class BaseWeaponCategoryLoot : IBaseWeaponCategoryLoot
    {
        private IBaseWeaponCategoryRepository<Datamodels.BaseWeaponCategory> _baseWeaponCategoryRepository;
        private IBaseMapper<Datamodels.BaseWeaponCategory, Domainmodels.BaseWeaponCategory> _mapper;
        private ILogger<BaseWeaponCategoryLoot> _logger;

        public BaseWeaponCategoryLoot(IBaseWeaponCategoryRepository<Datamodels.BaseWeaponCategory> baseWeaponCategoryRepo,
            IBaseMapper<Datamodels.BaseWeaponCategory, Domainmodels.BaseWeaponCategory> mapper,
            ILogger<BaseWeaponCategoryLoot> logger)
        {
            _baseWeaponCategoryRepository = baseWeaponCategoryRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Domainmodels.BaseWeaponCategory>> GetAllAsync()
        {
            var data = await _baseWeaponCategoryRepository.GetAllReadOnlyAsync();
            return await _mapper.MapDataToDomainAsync(data);
        }

        public async Task<Domainmodels.BaseWeaponCategory> GetByIdAsync(int id)
        {
            var data  = await _baseWeaponCategoryRepository.GetByIdReadOnlyAsync(id);
            return await _mapper.MapDataToDomainAsync(data);
        }
    }
}
