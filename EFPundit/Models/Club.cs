using EFPundit.Enums;
using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public class Club
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public League? League { get; set; }
        public List<Player>? Players { get; set; }
        public List<PlayerStats>? PlayerStats { get; set; }
        public ClubColours? ClubColours { get; set; }
        public GameTypes GameTypes { get; set; }
    }
}
