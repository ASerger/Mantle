using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mantle.Repository.DataRepo
{
    public class GeneratedWeaponRepository : BaseRepository<GeneratedWeapon, MantleDbContext>, IGeneratedWeaponRepository
    {
        public GeneratedWeaponRepository(MantleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
