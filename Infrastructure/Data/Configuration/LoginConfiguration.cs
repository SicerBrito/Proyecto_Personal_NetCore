using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class LoginConfiguration : IEntityTypeConfiguration<Login>
{
    public void Configure(EntityTypeBuilder<Login> builder)
    {
        builder.ToTable("Login");

        builder.Property(p => p.Id)
            .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
            .HasColumnName("IdLogin")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.EmailId)
            .HasColumnName("Email_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Emails)
            .WithMany(p => p.Logins)
            .HasForeignKey(p => p.EmailId);

        builder.Property(p => p.Password)
            .HasColumnName("Password")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.InfoId)
            .HasColumnName("Info_Id")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Datospersonales)
            .WithMany(p => p.Logins)
            .HasForeignKey(p => p.InfoId);

        builder.Property(p => p.Created_at)
            .HasColumnName("Created_at")
            .HasColumnType("TIMESTAMP")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
            
    }
}
