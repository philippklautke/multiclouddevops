using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace BlogApi.Extensions
{
    internal static class SwaggerExtensions
    {
        internal static IServiceCollection AddSwaggerDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSwaggerGen(ConfigureSwaggerOptions(configuration));
        }
        internal static IApplicationBuilder UseSwagger(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(ConfigureSwaggerUi(configuration));
            return builder;
        }
        private static Action<SwaggerGenOptions> ConfigureSwaggerOptions(IConfiguration configuration)
        {
            var swaggerConfig = configuration.GetSection("SwaggerSettings");
            return c =>
            {
                c.SwaggerDoc(swaggerConfig["Version"], new OpenApiInfo
                {
                    Title = swaggerConfig["Title"],
                    Version = swaggerConfig["Version"],
                    Description = swaggerConfig["Description"]
                });
                var filePath = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "BlogApi.xml");
                c.IncludeXmlComments(filePath);
            };
        }
        private static Action<SwaggerUIOptions> ConfigureSwaggerUi(IConfiguration configuration)
        {
            var swaggerConfig = configuration.GetSection("SwaggerSettings");
            return c =>
            {
                c.SwaggerEndpoint($"/swagger/{swaggerConfig["Version"]}/swagger.json", swaggerConfig["Title"]);
            };
        }
    }
}
