using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorPet.Infrastructure.Data.EntityMapper
{
    public class AgendamentoMapper : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamento");

            builder.HasKey(agendamento => agendamento.Id)
                .HasName("AgendamentoId");

            builder.Property(agendamento => agendamento.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .IsRequired();

            builder.Property(agendamento => agendamento.DataConsulta)
                .HasColumnType("datetime")
                .HasColumnName("DataConsulta")
                .IsRequired();

            builder
              .HasIndex(agendamento => agendamento.AnimalId)
              .HasDatabaseName("IX_Agendamento_AnimalId").IsUnique(false);

            builder
              .HasIndex(agendamento => agendamento.VeterinarioId)
              .HasDatabaseName("IX_Agendamento_VeterinarioId").IsUnique(false);

            //Animal -< Agendamentos
            builder
                .HasOne(agendamento => agendamento.Animal)
                .WithMany(animal => animal.Agendamentos)
                .HasForeignKey(agendamento => agendamento.AnimalId);

            //Veterinario -< Agendamentos
            builder
               .HasOne(agendamento => agendamento.Veterinario)
               .WithMany(veterinario => veterinario.Agendamentos)
               .HasForeignKey(agendamento => agendamento.VeterinarioId);
        }
    }
}
