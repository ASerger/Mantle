using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Repository.Contracts
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> InsertRecord(T record);
        Task<int> InsertRecords(IEnumerable<T> records);
    }
}
