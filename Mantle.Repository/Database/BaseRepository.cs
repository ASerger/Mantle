using Mantle.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Mantle.Repository.Database
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private MantleDbContext _db;

        public BaseRepository(MantleDbContext db)
        {
            _db = db;
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public void InsertRecord(T record)
        {
            _db.Add(record);
            _db.SaveChangesAsync();
        }

        public void InsertRecords(IEnumerable<T> records)
        {
            _db.AddRange(records);
            _db.SaveChangesAsync();
        }
    }
}
