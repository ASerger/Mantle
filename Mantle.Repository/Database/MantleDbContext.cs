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
        public DbSet<BaseProperty> BaseProperty { get; set; }
        public DbSet<BaseDice> BaseDice { get; set; }
        public DbSet<BaseWeaponCategory> BaseWeaponCategory { get; set; }
        public DbSet<BaseWeaponEffect> BaseWeaponEffect { get; set; }
        public DbSet<RarityLevel> RarityLevel { get; set; }
        public DbSet<GeneratedWeapon> GeneratedWeapon { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<EffectClass>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.Property(i => i.EffectName).HasColumnType("varchar(20)").IsRequired();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });

            mb.Entity<BaseDamageType>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.HasMany(bdt => bdt.BaseWeaponCategory).WithOne(bwc => bwc.BaseDamageType).HasForeignKey(f => f.BaseDamageTypeId);
                e.Property(i => i.DamageType).HasColumnType("varchar(20)").IsRequired();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });

            mb.Entity<BaseWeaponCategory>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.HasOne(bwc => bwc.BaseDamageType).WithMany(bdt => bdt.BaseWeaponCategory).HasForeignKey(f => f.BaseDamageTypeId).IsRequired();
                e.HasOne(bwc => bwc.BaseDice).WithMany(bd => bd.BaseWeaponCategory).HasForeignKey(f => f.BaseDiceId).IsRequired();
                e.HasMany(bwc => bwc.GeneratedWeapon).WithOne(gw => gw.BaseWeaponCategory).HasForeignKey(f => f.BaseWeaponCategoryId);
                e.Property(i => i.WeaponCategory).HasColumnType("varchar(20)").IsRequired();
                e.Property(i => i.Cost).HasColumnType("numeric(12,2)").IsRequired();
                e.Property(i => i.Weight).HasColumnType("numeric(4,2)").IsRequired();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });

            mb.Entity<BaseWeaponEffect>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.HasOne(bwe => bwe.EffectClass).WithMany(ec => ec.BaseWeaponEffect).HasForeignKey(f => f.EffectClassId).IsRequired();
                e.HasOne(bwe => bwe.BaseDice).WithMany(bd => bd.BaseWeaponEffect).HasForeignKey(f => f.BaseDiceId).IsRequired();
                e.HasMany(bwe => bwe.GeneratedWeapon).WithOne(gw => gw.BaseWeaponEffect).HasForeignKey(f => f.BaseWeaponEffectId);
                e.Property(i => i.EffectDescription).HasColumnType("varchar(25)").IsRequired();
                e.Property(i => i.Prefix).HasColumnType("varchar(25)").IsRequired();
                e.Property(i => i.Suffix).HasColumnType("varchar(25)").IsRequired();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
            });

            mb.Entity<BaseProperty>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
                e.Property(i => i.Property).HasColumnType("varchar(20)").IsRequired();
                e.Property(i => i.PropertyDescription).HasColumnType("varchar(700)").IsRequired();
            });

            mb.Entity<RarityLevel>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
                e.Property(i => i.RarityLevelName).HasColumnType("varchar(20)").IsRequired();
            });

            mb.Entity<GeneratedWeapon>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
                e.Property(i => i.GeneratedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.HasOne(gw => gw.BaseWeaponCategory).WithMany(bwc => bwc.GeneratedWeapon).HasForeignKey(f => f.BaseWeaponCategoryId).IsRequired();
                e.HasOne(gw => gw.BaseWeaponEffect).WithMany(bwe => bwe.GeneratedWeapon).HasForeignKey(f => f.BaseWeaponEffectId).IsRequired();
            });

            mb.Entity<BaseDice>(e =>
            {
                e.HasKey(i => i.Id);
                e.Property(i => i.Id).ValueGeneratedOnAdd();
                e.Property(i => i.ModifiedOn).HasColumnType("datetimeoffset(7)").HasDefaultValue();
                e.Property(i => i.ModifiedBy).HasColumnType("varchar(100)").HasDefaultValue();
                e.Property(i => i.Count).IsRequired();
                e.Property(i => i.Sides).IsRequired();
                e.Property(i => i.DiceDescription).HasColumnType("varchar(20)").IsRequired();
                e.HasMany(bd => bd.BaseWeaponCategory).WithOne(bwc => bwc.BaseDice).HasForeignKey(f => f.BaseDiceId);
                e.HasMany(bd => bd.BaseWeaponEffect).WithOne(bwe => bwe.BaseDice).HasForeignKey(f => f.BaseDiceId);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
