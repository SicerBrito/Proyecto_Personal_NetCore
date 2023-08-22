using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;
    public class Persona{

        [Key]
        public int NroDocumento { get; set; }
        public string ? TipoDocumentoFk { get; set; }
        public TipoDocumento ? TipoDeDocumentos { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Ocupacion { get; set; }
        public int Edad { get; set; }
        public ICollection<Login> ? Logins { get; set; }
        public ICollection<Contacto> ? Contactos { get; set; }
    }
