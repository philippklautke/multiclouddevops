using BlogApi.Data;
using BlogApi.Infrastructure.Interfaces;
using BlogApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlogApi.Extensions
{
    /// <summary>
    /// Extension for Service Collection
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Method to Add All Needed Dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFullDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration);
            services.AddSwaggerDependencies(configuration);
            services.AddContext(configuration);            
            services.AddServiceDependencies();
            return services;
        }
        private static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BlogDatabase");
            services.AddDbContext<BlogApiContext>(options =>
                options
                    .UseSqlServer(connectionString));
            return services;
        }
        private static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IBlogPostService,BlogPostService>();
            return services;
        }

    }
}
