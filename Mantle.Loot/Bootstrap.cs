using Mantle.Loot.Contracts.Mappers;
using Mantle.Loot.Mappers;
using Mantle.Repository.Contracts;
using Mantle.Repository.DataRepo;
using Microsoft.Extensions.DependencyInjection;
using Data = Mantle.DataModels.Models;
using Domain = Mantle.DomainModels.Models;

namespace Mantle.Loot
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IEffectClassRepository, EffectClassRepository>();
            services.AddScoped<IBaseWeaponCategoryRepository, BaseWeaponCategoryRepository>();
            services.AddScoped<IGeneratedWeaponRepository, GeneratedWeaponRepository>();

            services.AddScoped<IBaseMapper<Data.EffectClass, Domain.EffectClass>, EffectClassMapper>();
            services.AddScoped<IBaseMapper<Data.BaseWeaponCategory, Domain.BaseWeaponCategory>, BaseWeaponCategoryMapper>();
            services.AddScoped<IBaseMapper<Data.GeneratedWeapon, Domain.GeneratedWeapon>, GeneratedWeaponLootMapper>();
        }
    }
}
