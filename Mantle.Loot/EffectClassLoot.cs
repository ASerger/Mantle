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

        public async Task<IEnumerable<EffectClass>> GetAll()
        {
            return await _effectClassRepo.GetAll();
        }

        public async Task<EffectClass> GetById(int id)
        {
            return await _effectClassRepo.GetById(id);
        }
    }
}
