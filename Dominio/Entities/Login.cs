using System.ComponentModel.DataAnnotations;

namespace Dominio.Entities;

    public class Login{

        [Key]
        public int IdUser { get; set; }
        public string ? Email { get; set; }
        public string ? Password { get; set; }
        public int PersonaId { get; set; }
        public Persona ? Personas { get; set; }
        public DateTime Created_at { get; set; }

    }
