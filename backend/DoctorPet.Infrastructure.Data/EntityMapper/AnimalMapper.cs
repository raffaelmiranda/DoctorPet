using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorPet.Infrastructure.Data.EntityMapper
{
    public class AnimalMapper : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.ToTable("Animal");

            builder.HasKey(animal => animal.Id)
                .HasName("AnimalId");

            builder.Property(animal => animal.Nome)
                .HasColumnType("varchar(max)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(animal => animal.Idade)
                .HasColumnType("int")
                .HasColumnName("Idade")
                .IsRequired();

            builder.Property(animal => animal.DataCadastro)
               .HasColumnType("datetime")
               .HasColumnName("DataCadastro")
               .IsRequired();

            builder
                .HasOne(animal => animal.TipoAnimal)
                .WithOne(tipoAnimal => tipoAnimal.Animal)
                .HasForeignKey<Animal>(animal => animal.TipoAnimalId);

            builder
              .HasIndex(animal => animal.TipoAnimalId)
              .HasDatabaseName("IX_Animal_TipoAnimalId").IsUnique(false);

            builder
              .HasIndex(animal => animal.ClienteId)
              .HasDatabaseName("IX_Animal_ClienteId").IsUnique(false);

            //Cliente -< Animais
            builder
            .HasOne(animal => animal.Cliente)
            .WithMany(cliente => cliente.Animais)
            .HasForeignKey(animal => animal.ClienteId);
        }
    }
}
