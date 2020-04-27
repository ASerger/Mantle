using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

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

        public IEnumerable<EffectClass> GetAll()
        {
            return _effectClassRepo.GetAll();
        }

        public EffectClass GetById(int id)
        {
            return _effectClassRepo.GetById(id);
        }
    }
}
