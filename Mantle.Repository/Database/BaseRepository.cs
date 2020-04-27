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
