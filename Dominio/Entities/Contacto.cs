using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
    public class Contacto{

        [Key]
        public int PkContacto { get; set; }
        public int PersonaFk { get; set; }
        public Persona ? Personas { get; set; }
        public string ? ValorContacto { get; set; }
        public string ? TipoContactoFk { get; set; }
        public TipoContacto ? TipoDeContactos { get; set; }
        
    }
