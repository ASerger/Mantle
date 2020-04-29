using Mantle.Loot;
using Microsoft.Extensions.DependencyInjection;

namespace Mantle.API
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<Loot.Contracts.IEffectClassLoot, EffectClassLoot>();
        }
    }
}
