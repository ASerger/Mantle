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
        public virtual DbSet<BaseWeaponCategory> BaseWeaponCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<EffectClass>(ec =>
            {
                ec.HasKey(i => i.Id);
                ec.Property(i => i.Id).ValueGeneratedOnAdd();
                ec.Property("EffectName").HasColumnType("varchar(20)");
                ec.Property("ModifiedOn").HasDefaultValue();
                ec.Property("ModifiedBy").HasDefaultValue();
            });

            // TODO: 
            // Need to configure foreign key models still
            mb.Entity<BaseWeaponCategory>(bwc =>
            {
                bwc.HasKey(i => i.Id);
                bwc.Property(i => i.Id).ValueGeneratedOnAdd();
                bwc.Property("WeaponCategory").HasColumnType("varchar(20)");
                bwc.Property("Cost").HasColumnType("numeric(12,2)");
                bwc.Property("Weight").HasColumnType("numeric(4,2)");
                bwc.Property("ModifiedOn").HasDefaultValue();
                bwc.Property("ModifiedBy").HasDefaultValue();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
