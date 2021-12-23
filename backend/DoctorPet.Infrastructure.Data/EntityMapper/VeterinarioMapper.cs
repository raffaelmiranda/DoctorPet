using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorPet.Infrastructure.Data.EntityMapper
{
    public class VeterinarioMapper : IEntityTypeConfiguration<Veterinario>
    {
        public void Configure(EntityTypeBuilder<Veterinario> builder)
        {
            builder.ToTable("Veterinario");

            builder.HasKey(veterinario => veterinario.Id)
                .HasName("VeterinarioId");

            builder.Property(veterinario => veterinario.Nome)
                .HasColumnType("varchar(max)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(veterinario => veterinario.Geriatria)
                .HasColumnType("bit")
                .HasColumnName("Geriatria")
                .IsRequired();

            builder.Property(veterinario => veterinario.DataContratacao)
               .HasColumnType("datetime")
               .HasColumnName("DataContratacao")
               .IsRequired();

            builder.Property(veterinario => veterinario.DataCadastro)
               .HasColumnType("datetime")
               .HasColumnName("DataCadastro")
               .IsRequired();
        }
    }
}
