using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;

namespace Mantle.Repository.DataRepo
{
    public class EffectClassRepo<T> : BaseRepository<EffectClass>, IEffectClassRepo<EffectClass>
    {
        public EffectClassRepo(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
