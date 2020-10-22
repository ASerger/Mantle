using Mantle.Loot.Contracts.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;


namespace Mantle.Loot.Mappers
{
    public class GeneratedWeaponLootMapper : IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon>
    {
        public async Task<Domain.GeneratedWeapon> MapDataToDomainAsync(Data.GeneratedWeapon dataModel)
        {
            return await Task.FromResult(new Domain.GeneratedWeapon
            {
                Id = dataModel.Id,
                BaseWeaponCategoryId = dataModel.BaseWeaponCategoryId,
                BaseWeaponEffectId = dataModel.BaseWeaponEffetId,
                GeneratedOn = dataModel.GeneratedOn,
                ModifiedBy = dataModel.ModifiedBy,
                ModifiedOn = dataModel.ModifiedOn
            });
        }

        public async Task<List<Domain.GeneratedWeapon>> MapDataToDomainAsync(IEnumerable<Data.GeneratedWeapon> dataModels)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Data.GeneratedWeapon> MapDomainToDataAsync(Domain.GeneratedWeapon domainModel)
        {
            return await Task.FromResult(new Data.GeneratedWeapon
            {
                Id = domainModel.Id,
                BaseWeaponCategoryId = domainModel.BaseWeaponCategoryId,
                BaseWeaponEffetId = domainModel.BaseWeaponEffectId
            });
        }

        public async Task<List<Data.GeneratedWeapon>> MapDomainToDataAsync(IEnumerable<Domain.GeneratedWeapon> domainModels)
        {
            throw new System.NotImplementedException();
        }
    }
}
