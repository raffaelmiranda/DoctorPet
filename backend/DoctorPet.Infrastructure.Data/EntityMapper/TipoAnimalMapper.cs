using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorPet.Infrastructure.Data.EntityMapper
{
    public class TipoAnimalMapper : IEntityTypeConfiguration<TipoAnimal>
    {
        public void Configure(EntityTypeBuilder<TipoAnimal> builder)
        {
            builder.ToTable("TipoAnimal");

            builder
                .HasKey(tipoAnimal => tipoAnimal.Id)
                .HasName("TipoAnimalId");

            builder.Property(tipoAnimal => tipoAnimal.Nome)
                .HasColumnType("varchar(max)")
                .HasColumnName("Nome")
                .IsRequired();

            builder
                .Property(tipoAnimal => tipoAnimal.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .IsRequired();

            //Animal - Tipo Animal
            builder
                .HasOne(tipoAnimal => tipoAnimal.Animal)
                .WithOne(animal => animal.TipoAnimal)
                .HasForeignKey<Animal>(animal => animal.TipoAnimalId);
        }
    }
}
