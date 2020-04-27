using Mantle.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mantle.Repository.Database
{
    public class MantleDbContext : DbContext, IMantleDbContext
    {
        public MantleDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
