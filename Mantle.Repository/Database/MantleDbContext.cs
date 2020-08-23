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

        public DbSet<EffectClass> EffectClass { get; set; }
        public DbSet<BaseDamageType> BaseDamageType { get; set; }
        public DbSet<BaseWeaponCategory> BaseWeaponCategory { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<EffectClass>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.Property(i => i.EffectName).HasColumnType("varchar(20)");
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });

            mb.Entity<BaseDamageType>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.HasMany(bdt => bdt.BaseWeaponCategory).WithOne(bwc => bwc.BaseDamageType).HasForeignKey(f => f.BaseDamageTypeId);
                e.Property(i => i.DamageType).HasColumnType("varchar(20)");
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });

            mb.Entity<BaseWeaponCategory>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.HasOne(bwc => bwc.BaseDamageType).WithMany(bdt => bdt.BaseWeaponCategory).HasForeignKey(f => f.BaseDamageTypeId).IsRequired();
                e.Property(i => i.WeaponCategory).HasColumnType("varchar(20)");
                e.Property(i => i.Cost).HasColumnType("numeric(12,2)");
                e.Property(i => i.Weight).HasColumnType("numeric(4,2)");
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
