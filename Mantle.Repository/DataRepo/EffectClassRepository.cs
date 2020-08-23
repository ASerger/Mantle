using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;

namespace Mantle.Repository.DataRepo
{
    public class EffectClassRepository<T> : BaseRepository<EffectClass>, IEffectClassRepository<EffectClass>
    {
        public EffectClassRepository(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
