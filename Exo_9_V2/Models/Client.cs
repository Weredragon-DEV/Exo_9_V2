using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Exo_9_V2.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        [Required]
        [EmailAddress]
        public string Courriel { get; set; }

        public ICollection<Voiture> Voitures { get; set; }
    }
}