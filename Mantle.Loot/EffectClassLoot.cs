using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Loot
{
    public class EffectClassLoot : IEffectClassLoot
    {
        private IEffectClassRepo<EffectClass> _effectClassRepo;
        private ILogger<EffectClassLoot> _logger;

        public EffectClassLoot(IEffectClassRepo<EffectClass> effectClassRepo,
            ILogger<EffectClassLoot> logger)
        {
            _effectClassRepo = effectClassRepo;
            _logger = logger;
        }

        public async Task<IEnumerable<EffectClass>> GetAllAsync()
        {
            return await _effectClassRepo.GetAllReadOnlyAsync();
        }

        public async Task<EffectClass> GetByIdAsync(int id)
        {
            return await _effectClassRepo.GetByIdReadOnlyAsync(id);
        }
    }
}
