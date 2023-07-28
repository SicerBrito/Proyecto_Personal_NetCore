namespace Core.Entities;

    public class Email{
        public int Id { get; set; }
        public string ? Correo { get; set; }
        public ICollection<Login> ? Logins { get; set;}

    }
