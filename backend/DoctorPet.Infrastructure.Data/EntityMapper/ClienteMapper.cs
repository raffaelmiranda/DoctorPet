using DoctorPet.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorPet.Infrastructure.Data.EntityMapper
{
    public class ClienteMapper : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(cliente => cliente.Id)
                .HasName("ClienteId");

            builder.Property(cliente => cliente.Nome)
                .HasColumnType("varchar(max)")
                .HasColumnName("Nome")
                .IsRequired();

            builder.Property(cliente => cliente.Cpf)
               .HasColumnType("varchar(max)")
               .HasColumnName("Cpf")
               .IsRequired();

            builder.Property(cliente => cliente.DataCadastro)
               .HasColumnType("datetime")
               .HasColumnName("DataCadastro")
               .IsRequired();
        }
    }
}
