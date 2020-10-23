using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;

namespace Mantle.Repository.DataRepo
{
    public class EffectClassRepository : BaseRepository<EffectClass, MantleDbContext>, IEffectClassRepository
    {
        public EffectClassRepository(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
