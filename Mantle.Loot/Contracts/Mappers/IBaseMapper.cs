using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts.Mappers
{
    public interface IBaseMapper<T, D> where T: class where D: class
    {
        public Task<D> MapDataToDomainAsync(T dataModel);
        public Task<List<D>> MapDataToDomainAsync(IEnumerable<T> dataModels);
        public Task<T> MapDomainToDataAsync(D domainModel);
        public Task<List<T>> MapDomainToDataAsync(IEnumerable<D> domainModels);
    }
}
