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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<BaseDataModel>(bdm =>
            {
                bdm.HasKey(i => i.Id);
                bdm.Property(i => i.Id).ValueGeneratedOnAdd();
                bdm.Property("ModifiedOn").HasDefaultValue();
                bdm.Property("ModifiedBy").HasDefaultValue();
            });

            mb.Entity<EffectClass>(ec =>
            {
                ec.Property("EffectName").HasColumnType("varchar(20)");
            });

            // TODO: 
            // Need to configure foreign key models still
            mb.Entity<BaseWeaponCategory>(bwc =>
            {
                bwc.Property("WeaponCategory").HasColumnType("varchar(20)");
                bwc.Property("Cost").HasColumnType("numeric(12,2)");
                bwc.Property("Weight").HasColumnType("numeric(4,2)");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
