using Mantle.DataModels.Models;
using Mantle.Loot.Contracts;
using Mantle.Repository.Contracts;
using Mantle.Repository.DataRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Mantle.Loot
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IEffectClassRepository<EffectClass>, EffectClassRepository<EffectClass>>();
            services.AddScoped<IBaseWeaponCategoryRepository<BaseWeaponCategory>, BaseWeaponCategoryRepository<BaseWeaponCategory>>();
        }
    }
}
