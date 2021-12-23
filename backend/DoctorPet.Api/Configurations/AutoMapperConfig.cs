using DoctorPet.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorPet.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static IServiceCollection AddAutoMapperConfig(this IServiceCollection services)
        {
            services.AddAutoMapper(opt =>
            {
                opt.AddProfile(new DomainToModelProfile());
                opt.AddProfile(new ModelToDomainProfile());
            });

            return services;
        }
    }
}
