using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class Documento{
        [Key]
        public int Id { get; set; }
        public int Numero { get; set; }
        public int TipoId { get; set; }
        public TipoDocumento ? TipoDeDocumento { get; set; }  
        public ICollection<InfoPersonal> ? DatosPersonales { get; set; }
    }
