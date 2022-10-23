using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public class Player
    { 
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Country? Country { get; set; }
        public string? Dob { get; set; }
        public Club? Club { get; set; }
        public string? Foot { get; set; }
        public List<PlayerStats>? PlayerStats { get; set; }

    }
}
