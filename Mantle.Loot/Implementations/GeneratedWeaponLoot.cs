using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;

namespace Mantle.Loot.Implementations
{
    public class GeneratedWeaponLoot : IGeneratedWeaponLoot
    {
        private IGeneratedWeaponRepository _generatedWeaponRepository;
        private ILogger<GeneratedWeaponLoot> _logger;

        public GeneratedWeaponLoot(IGeneratedWeaponRepository generatedWeaponRepository,
            ILogger<GeneratedWeaponLoot> logger)
        {
            _generatedWeaponRepository = generatedWeaponRepository;
            _logger = logger;
        }

        public Task<Domain.GeneratedWeapon> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
