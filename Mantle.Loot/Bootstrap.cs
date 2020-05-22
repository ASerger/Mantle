using Mantle.DataModels.Models;
using Mantle.Repository.Contracts;
using Mantle.Repository.DataRepo;
using Microsoft.Extensions.DependencyInjection;

namespace Mantle.Loot
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IEffectClassRepo<EffectClass>, EffectClassRepository<EffectClass>>();
            services.AddScoped<IWeaponClassRepo<WeaponClass>, WeaponClassRepository<WeaponClass>>();
        }
    }
}
