using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TunnelAPI.Models
{
    public class RendezVousModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RendezVousId { get; set; }

        [Required]
        [StringLength(10, ErrorMessage ="le code client ne doit pas depassé 10 caractères")]
        public string CodeClient { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Nom length can't be more than 50 characters.")]
        public string Nom { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Prenom length can't be more than 50 characters.")]
        public string Prenom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Notes length can't be more than 200 characters.")]
        public string Notes { get; set; }
    }
}
