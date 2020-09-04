using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Repository.Contracts
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllReadOnlyAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> InsertRecordAsync(T record);
        Task<int> InsertRecordsAsync(IEnumerable<T> records);
    }
}
