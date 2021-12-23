using DoctorPet.Api.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace DoctorPet.Api.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfig(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
                options.Filters.Add(new ConsumesAttribute("application/json"));
                options.Filters.Add(typeof(ModelStateFilter), 1);
                options.Filters.Add(typeof(NotificacaoFilter), 2);

                options.FormatterMappings.ClearMediaTypeMappingForFormat("application/xml");
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            })
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.WriteIndented = true;
                //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            return services;
        }
    }
}
