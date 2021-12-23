using DoctorPet.Application.AppServices;
using DoctorPet.Application.Interfaces;
using DoctorPet.Domain.Core.Notifications;
using DoctorPet.Domain.Interfaces.Repositories;
using DoctorPet.Infrastructure.Data.Context;
using DoctorPet.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorPet.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void Register(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddTransient<IClienteAppService, ClienteAppService>();
            services.AddTransient<IAnimalAppService, AnimalAppService>();
            
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddDbContext<DoctorPetContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<INotificator, Notificator>();

        }
    }
}
