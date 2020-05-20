using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mantle.Repository.Database
{
    public class MantleDbContext : DbContext, IMantleDbContext
    {
        public MantleDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<EffectClass> EffectClass { get; set; }
        public virtual DbSet<WeaponClass> WeaponClass { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<EffectClass>(ec =>
            {
                ec.HasKey(i => i.Id);
                ec.Property("EffectName").HasColumnType("varchar(20)");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
