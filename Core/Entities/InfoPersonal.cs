using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class InfoPersonal{
        [Key]
        public int Id { get; set; }
        public string ? NombreCompleto { get; set; }
        public string ? Ocupacion { get; set; }
        public int Edad { get; set; }
        public int TelefonoId { get; set; }
        public Telefono ? Telefonos { get; set; }
        public int DocumentoId { get; set; }
        public Documento ? Documentos { get; set; }
        public ICollection<Login> ? Logins { get; set; }
    }
