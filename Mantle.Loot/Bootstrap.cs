using Mantle.Loot.Contracts.Mappers;
using Mantle.Loot.Mappers;
using Mantle.Repository.Contracts;
using Mantle.Repository.DataRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Mantle.Loot
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IEffectClassRepository<DataModels.Models.EffectClass>, EffectClassRepository<DataModels.Models.EffectClass>>();
            services.AddScoped<IBaseWeaponCategoryRepository<DataModels.Models.BaseWeaponCategory>, BaseWeaponCategoryRepository<DataModels.Models.BaseWeaponCategory>>();

            services.AddScoped<IBaseMapper<DataModels.Models.BaseWeaponCategory, DomainModels.Models.BaseWeaponCategory>, BaseWeaponCategoryMapper<DataModels.Models.BaseWeaponCategory, DomainModels.Models.BaseWeaponCategory>>();
        }
    }
}
