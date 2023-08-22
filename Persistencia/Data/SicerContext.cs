using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia.Data;
    public class SicerContext : DbContext{
        public SicerContext(DbContextOptions<SicerContext> options) : base(options){

        }


        public DbSet<Contacto> Contactos { get; set; } = null!;
        public DbSet<Login> Logins { get; set; } = null!;
        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<TipoContacto> TipoDeContactos { get; set; } = null!;
        public DbSet<TipoDocumento> TipoDeDocumentos { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
