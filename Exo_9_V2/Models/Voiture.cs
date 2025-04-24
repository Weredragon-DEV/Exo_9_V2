using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exo_9_V2.Models
{
    public class Voiture
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Marque { get; set; }

        [Required]
        public string Modele { get; set; }

        [Range(1900, 2100)]
        public int Annee { get; set; }

        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}