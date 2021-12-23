using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorPet.Api.Configurations
{
    public static class ApiVersioningConfig
    {
        public static IServiceCollection AddApiVersioningConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;

                options.ApiVersionReader = ApiVersionReader.Combine(
                    new HeaderApiVersionReader("x-api-version"),
                    new QueryStringApiVersionReader(),
                    new UrlSegmentApiVersionReader());
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            return services;
        }
        public static IApplicationBuilder UseApiVersioningConfig(this IApplicationBuilder app)
        {
            app.UseApiVersioning();

            return app;
        }
    }
}
