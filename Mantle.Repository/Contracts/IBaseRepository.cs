using System.Collections.Generic;

namespace Mantle.Repository.Contracts
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        void InsertRecord(T record);
        void InsertRecords(IEnumerable<T> records);
    }
}
