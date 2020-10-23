using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mantle.Repository.Contracts;
using Microsoft.Extensions.Logging;
using Mantle.Loot.Contracts.Mappers;
using Mantle.DomainModels.Models;

namespace Mantle.Loot.Implementations
{
    public class GeneratedWeaponLoot : IGeneratedWeaponLoot
    {
        private IGeneratedWeaponRepository _generatedWeaponRepository;
        private IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon> _genWeaponMapper;
        private ILogger<GeneratedWeaponLoot> _logger;

        public GeneratedWeaponLoot(IGeneratedWeaponRepository generatedWeaponRepository,
            IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon> genWeaponMapper,
            ILogger<GeneratedWeaponLoot> logger)
        {
            _generatedWeaponRepository = generatedWeaponRepository;
            _genWeaponMapper = genWeaponMapper;
            _logger = logger;
        }

        public async Task<IEnumerable<GeneratedWeapon>> GetAllReadOnlyAsync()
        {
            var data = await _generatedWeaponRepository.GetAllReadOnlyAsync();

            return await _genWeaponMapper.MapDataToDomainAsync(data);
        }

        public async Task<Domain.GeneratedWeapon> GetByIdAsync(int id)
        {
            var data = await _generatedWeaponRepository.GetByIdAsync(id);

            return await _genWeaponMapper.MapDataToDomainAsync(data);
        }

        public async Task<int> InsertRecord(Data.GeneratedWeapon dataGeneratedWeapon)
        {
            return await _generatedWeaponRepository.InsertRecordAsync(dataGeneratedWeapon);
        }

        public async Task<Domain.GeneratedWeapon> RollNewRandomWeapon()
        {
            // select relevant id's at random (at the moment only: base weapon category, base weapon effect)
            var rand = new Random();
            var data = new Data.GeneratedWeapon
            {
                BaseWeaponCategoryId = rand.Next(1, 37),
                BaseWeaponEffectId = rand.Next(1, 39),
            };

            await InsertRecord(data);
            return await _genWeaponMapper.MapDataToDomainAsync(data);
        }
    }
}
