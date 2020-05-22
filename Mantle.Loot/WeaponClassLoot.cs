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
    public class WeaponClassLoot : IWeaponClassLoot
    {
        private IWeaponClassRepo<WeaponClass> _weaponClassRepo;
        private ILogger<WeaponClassLoot> _logger;

        public WeaponClassLoot(IWeaponClassRepo<WeaponClass> weaponClassRepo,
            ILogger<WeaponClassLoot> logger)
        {
            _weaponClassRepo = weaponClassRepo;
            _logger = logger;
        }

        public async Task<IEnumerable<WeaponClass>> GetAllAsync()
        {
            return await _weaponClassRepo.GetAllReadOnlyAsync();
        }

        public async Task<WeaponClass> GetByIdAsync(int id)
        {
            return await _weaponClassRepo.GetByIdReadOnlyAsync(id);
        }
    }
}
