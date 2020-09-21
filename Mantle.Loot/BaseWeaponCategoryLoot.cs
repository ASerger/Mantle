using Datamodels = Mantle.DataModels.Models;
using Domainmodels = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mantle.DomainModels.Models;

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

        public async Task<BaseWeaponCategory> AddRecordAsync(BaseWeaponCategory domainModel)
        {
            var data = await _mapper.MapDomainToDataAsync(domainModel);
            var addedRecord = await _baseWeaponCategoryRepository.InsertRecordAsync(data);

            return await _mapper.MapDataToDomainAsync(addedRecord);
        }

        public async Task<IEnumerable<Domainmodels.BaseWeaponCategory>> GetAllAsync()
        {
            var domain = await _mapper.MapDataToDomainAsync(await _baseWeaponCategoryRepository.GetAllReadOnlyAsync());
            return domain;
        }

        public async Task<Domainmodels.BaseWeaponCategory> GetByIdAsync(int id)
        {
            var domain = await _mapper.MapDataToDomainAsync(await _baseWeaponCategoryRepository.GetByIdAsync(id));
            return domain;
        }
    }
}
