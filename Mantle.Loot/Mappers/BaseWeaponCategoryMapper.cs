using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;
using Mantle.Loot.Contracts.Mappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Mappers
{
    public class BaseWeaponCategoryMapper : IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>
    {
        Task<Domain.BaseWeaponCategory> IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>.MapDataToDomainAsync(Data.BaseWeaponCategory dataModel)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Domain.BaseWeaponCategory>> IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>.MapDataToDomainAsync(IEnumerable<Data.BaseWeaponCategory> dataModel)
        {
            throw new NotImplementedException();
        }

        Task<Data.BaseWeaponCategory> IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>.MapDomainToDataAsync(Domain.BaseWeaponCategory domainModel)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Data.BaseWeaponCategory>> IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>.MapDomainToDataAsync(IEnumerable<Domain.BaseWeaponCategory> domainModel)
        {
            throw new NotImplementedException();
        }
    }
}
