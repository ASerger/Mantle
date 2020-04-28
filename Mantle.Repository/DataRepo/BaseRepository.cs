using Mantle.Repository.Contracts;
using Mantle.Repository.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mantle.Repository.DataRepo
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private MantleDbContext _db;

        public BaseRepository(MantleDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _db.FindAsync<T>(id);
        }

        public async Task<int> InsertRecord(T record)
        {
            _db.Add(record);
            return await _db.SaveChangesAsync();
        }

        public async Task<int> InsertRecords(IEnumerable<T> records)
        {
            _db.AddRange(records);
            return await _db.SaveChangesAsync();
        }



        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BaseRepository()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
