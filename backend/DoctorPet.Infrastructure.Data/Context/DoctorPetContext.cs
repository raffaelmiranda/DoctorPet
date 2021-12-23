using DoctorPet.Domain.Entities;
using DoctorPet.Infrastructure.Data.EntityMapper;
using DoctorPet.Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DoctorPet.Infrastructure.Data.Context
{
    public class DoctorPetContext: DbContext
    {
        public DoctorPetContext(DbContextOptions<DoctorPetContext> options) : base(options) { }

       
        public DbSet<Animal> Animais { get; set; }
        public DbSet<TipoAnimal> TipoAnimais { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AnimalMapper());
            modelBuilder.ApplyConfiguration(new TipoAnimalMapper());
            modelBuilder.ApplyConfiguration(new AtendimentoMapper());
            modelBuilder.ApplyConfiguration(new ClienteMapper());
            modelBuilder.ApplyConfiguration(new AgendamentoMapper());
            modelBuilder.ApplyConfiguration(new VeterinarioMapper());

            modelBuilder.Seed();


            base.OnModelCreating(modelBuilder);
        }
    }
}
