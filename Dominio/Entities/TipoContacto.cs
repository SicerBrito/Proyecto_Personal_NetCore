using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
    public class TipoContacto{
        
        [Key]
        public string ? PkNombre { get; set; }
        public ICollection<Contacto> ? Contactos { get; set; }
    }
