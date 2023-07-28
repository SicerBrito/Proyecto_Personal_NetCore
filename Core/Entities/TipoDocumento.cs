using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class TipoDocumento{

        [Key]
        public int Id { get; set; }
        public int DNI { get; set; }
        public int Cedula { get; set; }
        public int Pasaporte { get; set; }
        public int Licencia { get; set; }
        public ICollection<Documento> ? Documentos { get; set; }
        
    }
}