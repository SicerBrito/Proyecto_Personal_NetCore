using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

    public class PaginaContext : DbContext{
        public PaginaContext(DbContextOptions<PaginaContext> options) : base (options){

        }

        public DbSet<Documento> Documentos { get; set; } = null!;
        public DbSet<Email> Emails { get; set; } = null!;
        public DbSet<InfoPersonal> DatosPersonales { get; set; } = null!;
        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<Telefono> Telefonos { get; set; } = null!;
        public DbSet<TipoDocumento> TipoDeDocumentos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder){
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
