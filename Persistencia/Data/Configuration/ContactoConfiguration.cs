using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ContactoConfiguration : IEntityTypeConfiguration<Contacto>
{
    public void Configure(EntityTypeBuilder<Contacto> builder)
    {
        builder.ToTable("Contacto");

        builder.Property(p => p.PkContacto)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("PkContacto")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.PersonaFk)
            .HasColumnName("PersonaFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Personas)
            .WithMany(p => p.Contactos)
            .HasForeignKey(p => p.PersonaFk);

        builder.Property(p => p.ValorContacto)
            .HasColumnName("ValorContacto")
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.TipoContactoFk)
            .HasColumnName("TipoContactoFk")
            .HasColumnType("varchar")
            .HasMaxLength(20)
            .IsRequired();

        builder.HasOne(p => p.TipoDeContactos)
            .WithMany(p => p.Contactos)
            .HasForeignKey(p => p.TipoContactoFk);

            
    }
}
