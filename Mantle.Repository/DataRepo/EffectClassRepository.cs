using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;

namespace Mantle.Repository.DataRepo
{
    public class EffectClassRepository<T> : BaseRepository<EffectClass>, IEffectClassRepo<EffectClass>
    {
        public EffectClassRepository(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
