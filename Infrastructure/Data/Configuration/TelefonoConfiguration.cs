using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class TelefonoConfiguration : IEntityTypeConfiguration<Telefono>
{
    public void Configure(EntityTypeBuilder<Telefono> builder)
    {
        builder.ToTable("Telefono");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdTelefono")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.Telefonos)
            .HasColumnName("Telefonos")
            .HasColumnType("double")
            .IsRequired();


    }
}
