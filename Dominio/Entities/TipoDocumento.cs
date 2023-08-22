using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
    public class TipoDocumento{

        [Key]
        public string ? PkNombre { get; set; }
        public ICollection<Persona> ? Personas { get; set; }
        
    }
