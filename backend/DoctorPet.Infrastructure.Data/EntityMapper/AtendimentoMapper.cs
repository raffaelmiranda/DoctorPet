using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorPet.Infrastructure.Data.EntityMapper
{
    public class AtendimentoMapper : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimento");

            builder.HasKey(atendimento => new { atendimento.VeterinarioId, atendimento.AnimalId });

            builder.Property(atendimento => atendimento.Diagnostico)
                .HasColumnType("varchar(max)")
                .HasColumnName("Diagnostico")
                .IsRequired();

            builder.Property(atendimento => atendimento.DataAtendimento)
                .HasColumnType("datetime")
                .HasColumnName("DataAtendimento")
                .IsRequired();

            builder.Property(atendimento => atendimento.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .IsRequired();

            builder
                .HasIndex(atendimento => atendimento.AnimalId)
                .HasDatabaseName("IX_Atendimento_AnimalId").IsUnique(false);

            builder
               .HasIndex(atendimento => atendimento.VeterinarioId)
               .HasDatabaseName("IX_Atendimento_VeterinarioId").IsUnique(false);

            builder
                .HasOne(atendimento => atendimento.Animal)
                .WithMany(animal => animal.Atendimentos)
                .HasForeignKey(atendimento => atendimento.AnimalId);


            builder
                .HasOne(atendimento => atendimento.Veterinario)
                .WithMany(veterinario => veterinario.Atendimentos)
                .HasForeignKey(atendimento => atendimento.VeterinarioId);
        }
    }
}
