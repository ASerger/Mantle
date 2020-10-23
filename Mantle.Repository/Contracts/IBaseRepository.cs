using Mantle.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mantle.Repository.Contracts
{
    public interface IBaseRepository<T> : IDisposable where T : BaseDataModel
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllReadOnlyAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> InsertRecordAsync(T record);
        Task<int> InsertRecordsAsync(IEnumerable<T> records);
        Task<int> UpdateRecordAsync(T record);
        Task<int> UpdateRecordsAsync(IEnumerable<T> records);
    }
}
