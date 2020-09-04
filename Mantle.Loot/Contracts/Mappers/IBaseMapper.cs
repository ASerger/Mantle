using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts.Mappers
{
    public interface IBaseMapper<T, D> where T: class where D: class
    {
        Task<D> MapDataToDomainAsync(T dataModel);
        Task<IEnumerable<D>> MapDataToDomainAsync(IEnumerable<T> dataModel);
        Task<T> MapDomainToDataAsync(D domainModel);
        Task<IEnumerable<T>> MapDomainToDataAsync(IEnumerable<D> domainModel);
    }
}
