using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mantle.Loot.Contracts.Mappers
{
    public interface IBaseWeaponCategoryMapper<T, D> where T: class where D: class
    {
        Task<D> MapDataToDomain(T dataModel);
        Task<T> MapDomainToData(D domainModel);
    }
}
