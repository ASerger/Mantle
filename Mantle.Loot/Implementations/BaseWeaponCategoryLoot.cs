using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Loot.Implementations
{
    public class BaseWeaponCategoryLoot : IBaseWeaponCategoryLoot
    {
        private IBaseWeaponCategoryRepository _baseWeaponCategoryRepository;
        private IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory> _mapper;
        private ILogger<BaseWeaponCategoryLoot> _logger;

        public BaseWeaponCategoryLoot(IBaseWeaponCategoryRepository baseWeaponCategoryRepo,
            IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory> mapper,
            ILogger<BaseWeaponCategoryLoot> logger)
        {
            _baseWeaponCategoryRepository = baseWeaponCategoryRepo;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<Domain.BaseWeaponCategory>> GetAllAsync()
        {
            var domain = await _mapper.MapDataToDomainAsync(await _baseWeaponCategoryRepository.GetAllReadOnlyAsync());
            return domain;
        }

        public async Task<Domain.BaseWeaponCategory> GetByIdAsync(int id)
        {
            var domain = await _mapper.MapDataToDomainAsync(await _baseWeaponCategoryRepository.GetByIdAsync(id));
            return domain;
        }
    }
}
