using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mantle.Repository.DataRepo
{
    public class WeaponClassRepository<T> : BaseRepository<WeaponClass>, IWeaponClassRepo<WeaponClass>
    {
        public WeaponClassRepository(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
