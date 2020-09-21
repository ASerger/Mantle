using Mantle.Loot.Contracts.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;

namespace Mantle.Loot.Mappers
{
    public class EffectClassMapper<T, D> : IBaseMapper<Data.EffectClass, Domain.EffectClass>
    {
        public async Task<Domain.EffectClass> MapDataToDomainAsync(Data.EffectClass dataModel)
        {
            var domainModel = new Domain.EffectClass
            {
                Id = dataModel.Id,
                DiceCount = dataModel.DiceCount,
                EffectName = dataModel.EffectName,
                ModifiedBy = dataModel.ModifiedBy,
                ModifiedOn = dataModel.ModifiedOn
            };
            return await Task.FromResult(domainModel);
        }

        public async Task<List<Domain.EffectClass>> MapDataToDomainAsync(IEnumerable<Data.EffectClass> dataModels)
        {
            var domainModels = new List<Domain.EffectClass>();
            foreach (var dataModel in dataModels)
            {
                domainModels.Add(await MapDataToDomainAsync(dataModel));
            }

            return await Task.FromResult(domainModels);
        }

        public async Task<Data.EffectClass> MapDomainToDataAsync(Domain.EffectClass domainModel)
        {
            var dataModel = new Data.EffectClass
            {
                Id = domainModel.Id,
                DiceCount = domainModel.DiceCount,
                EffectName = domainModel.EffectName,
                ModifiedBy = domainModel.ModifiedBy,
                ModifiedOn = domainModel.ModifiedOn
            };
            return await Task.FromResult(dataModel);
        }

        public async Task<List<Data.EffectClass>> MapDomainToDataAsync(IEnumerable<Domain.EffectClass> domainModels)
        {
            var dataModels = new List<Data.EffectClass>();
            foreach (var domainModel in domainModels)
            {
                dataModels.Add(await MapDomainToDataAsync(domainModel));
            }

            return await Task.FromResult(dataModels);
        }
    }
}
