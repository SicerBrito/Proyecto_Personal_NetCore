using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class Telefono{
        [Key]
        public int Id { get; set; }
        public double Telefonos { get; set;}
        public ICollection<InfoPersonal> ? DatosPersonales { get; set; }
        
    }
