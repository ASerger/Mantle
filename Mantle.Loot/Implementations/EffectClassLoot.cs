using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Loot.Contracts.Mappers;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Loot.Implementations
{
    public class EffectClassLoot : IEffectClassLoot
    {
        private IEffectClassRepository _effectClassRepo;
        private IBaseMapper<DataModels.Models.EffectClass, DomainModels.Models.EffectClass> _effectClassMapper;
        private ILogger<EffectClassLoot> _logger;

        public EffectClassLoot(IEffectClassRepository effectClassRepo,
            IBaseMapper<DataModels.Models.EffectClass, DomainModels.Models.EffectClass> effectClassMapper,
            ILogger<EffectClassLoot> logger)
        {
            _effectClassRepo = effectClassRepo;
            _effectClassMapper = effectClassMapper;
            _logger = logger;
        }

        public async Task<IEnumerable<DomainModels.Models.EffectClass>> GetAllAsync()
        {
            return await _effectClassMapper.MapDataToDomainAsync(await _effectClassRepo.GetAllReadOnlyAsync());
        }

        public async Task<DomainModels.Models.EffectClass> GetByIdAsync(int id)
        {
            return await _effectClassMapper.MapDataToDomainAsync(await _effectClassRepo.GetByIdAsync(id));
        }
    }
}
