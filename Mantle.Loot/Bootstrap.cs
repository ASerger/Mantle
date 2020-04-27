using Mantle.DataModels.Models;
using Microsoft.Extensions.DependencyInjection;
using Mantle.Repository.Contracts;
using Mantle.Repository.DataRepo;

namespace Mantle.Loot
{
    public static class Bootstrap
    {
        public static void AddDependencies(IServiceCollection services)
        {
            services.AddScoped<IEffectClassRepo<EffectClass>, EffectClassRepo<EffectClass>>();
        }
    }
}
