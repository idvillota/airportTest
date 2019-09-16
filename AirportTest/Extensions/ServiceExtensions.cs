using Airport.Repository;
using Airport.Services;
using AirportTest.Contracts.Logger;
using AirportTest.Contracts.Repository;
using AirportTest.Contracts.Service;
using AirportTest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace AirportTest.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerService>();
            services.AddTransient<IAirportService, AirportService>();
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:ConnectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Airport API",
                    Description = "This is the airport API, the main functionality is measure the distance between two airports."
                });
                c.DescribeAllEnumsAsStrings();
                c.DescribeStringEnumsInCamelCase();

            });
        }

    }
    
}
