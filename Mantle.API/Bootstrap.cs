using Mantle.Loot.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Mantle.API
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<Loot.Contracts.IEffectClassLoot, EffectClassLoot>();
            services.AddScoped<Loot.Contracts.IBaseWeaponCategoryLoot, BaseWeaponCategoryLoot>();
            services.AddScoped<Loot.Contracts.IGeneratedWeaponLoot, GeneratedWeaponLoot>();
        }
    }
}
