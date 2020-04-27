﻿using Mantle.DataModels.Models;
using Microsoft.Extensions.DependencyInjection;
using Mantle.Loot;

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
