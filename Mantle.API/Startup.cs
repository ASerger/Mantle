using Mantle.Repository.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Mantle.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string AllowAll = "_allowAll";
        readonly string ProductionCors = "_productionCors";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAll,
                    // TODO: Fix Cors policy once a deployed environment is available
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
                options.AddPolicy(name: ProductionCors,
                    builder =>
                    {
                    });
            });

            services.AddControllers();
            services.AddDbContext<MantleDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:MantleDb"]);
            });

            services.AddAuthentication("Bearer")
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:5001/";
                    options.RequireHttpsMetadata = false;
                    options.Audience = "Mantle.API";
                });

            services.AddSwaggerGen(swag =>
            {
                InitializeSwagger(swag);
            });

            Mantle.API.Bootstrap.AddDependencies(services);
            Mantle.Loot.Bootstrap.AddDependencies(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            if (env.IsProduction())
            {
                app.UseCors(ProductionCors);
            }
            else
            {
                app.UseCors(AllowAll);
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Mantle V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        internal void InitializeSwagger(SwaggerGenOptions swag)
        {
            swag.SwaggerDoc("v1", info: new OpenApiInfo { Title = "Mantle", Version = "V1" });
            swag.CustomSchemaIds(o => o.FullName);
            swag.AddSecurityDefinition("Bearer",
                new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
            swag.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
            swag.IncludeXmlComments(GetSwaggerXmlPath());
        }

        internal string GetSwaggerXmlPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(AppContext.BaseDirectory, xmlFile);
        }
    }
}
