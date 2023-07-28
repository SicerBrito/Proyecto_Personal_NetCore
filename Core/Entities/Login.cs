using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

    public class Login{

        [Key]
        public int Id { get; set; }
        public int EmailId { get; set; }
        public Email ? Emails { get; set; }
        public string ? Password { get; set; }
        public int InfoId { get; set; }
        public InfoPersonal ? Datospersonales { get; set; }
        public DateTime Created_at { get; set; }

    }
