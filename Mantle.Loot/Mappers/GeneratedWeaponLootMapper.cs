using Mantle.Loot.Contracts.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;


namespace Mantle.Loot.Mappers
{
    public class GeneratedWeaponLootMapper : IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon>
    {
        public Task<Domain.GeneratedWeapon> MapDataToDomainAsync(Data.GeneratedWeapon dataModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Domain.GeneratedWeapon>> MapDataToDomainAsync(IEnumerable<Data.GeneratedWeapon> dataModels)
        {
            throw new System.NotImplementedException();
        }

        public Task<Data.GeneratedWeapon> MapDomainToDataAsync(Domain.GeneratedWeapon domainModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Data.GeneratedWeapon>> MapDomainToDataAsync(IEnumerable<Domain.GeneratedWeapon> domainModels)
        {
            throw new System.NotImplementedException();
        }
    }
}
