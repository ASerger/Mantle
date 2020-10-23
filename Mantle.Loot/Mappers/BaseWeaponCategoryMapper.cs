using Mantle.Loot.Contracts.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;

namespace Mantle.Loot.Mappers
{
    public class BaseWeaponCategoryMapper : IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>
    {
        public async Task<Domain.BaseWeaponCategory> MapDataToDomainAsync(Data.BaseWeaponCategory dataModel)
        {
            var domainModel = new Domain.BaseWeaponCategory
            {
                Id = dataModel.Id,
                BaseDamageTypeId = dataModel.BaseDamageTypeId,
                BaseDamageType = dataModel.BaseDamageType.DamageType,
                BaseDiceId = dataModel.BaseDiceId,
                BaseDice = dataModel.BaseDice.DiceDescription,
                WeaponCategory = dataModel.WeaponCategory,
                Cost = dataModel.Cost,
                IsMartial = dataModel.IsMartial,
                IsRange = dataModel.IsRange,
                Weight = dataModel.Weight,
                ModifiedBy = dataModel.ModifiedBy,
                ModifiedOn = dataModel.ModifiedOn
            };

            return await Task.FromResult(domainModel);
        }

        public async Task<List<Domain.BaseWeaponCategory>> MapDataToDomainAsync(IEnumerable<Data.BaseWeaponCategory> dataModels)
        {
            var domainModels = new List<Domain.BaseWeaponCategory>();
            foreach(var dataModel in dataModels)
            {
                domainModels.Add(await MapDataToDomainAsync(dataModel));
            }

            return await Task.FromResult(domainModels);
        }

        public async Task<Data.BaseWeaponCategory> MapDomainToDataAsync(Domain.BaseWeaponCategory domainModel)
        {
            var dataModel = new Data.BaseWeaponCategory
            {
                Id = domainModel.Id,
                BaseDamageTypeId = domainModel.BaseDamageTypeId,
                BaseDiceId = domainModel.BaseDiceId,
                Cost = domainModel.Cost,
                IsMartial = domainModel.IsMartial,
                IsRange = domainModel.IsRange,
                WeaponCategory = domainModel.WeaponCategory,
                Weight = domainModel.Weight,
                ModifiedBy = domainModel.ModifiedBy,
                ModifiedOn = domainModel.ModifiedOn
            };

            return await Task.FromResult(dataModel);
        }

        public async Task<List<Data.BaseWeaponCategory>> MapDomainToDataAsync(IEnumerable<Domain.BaseWeaponCategory> domainModels)
        {
            var dataModels = new List<Data.BaseWeaponCategory>();
            foreach(var domainModel in domainModels)
            {
                dataModels.Add(await MapDomainToDataAsync(domainModel));
            }

            return await Task.FromResult(dataModels);
        }
    }
}
