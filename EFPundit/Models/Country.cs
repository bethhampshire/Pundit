
using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Nationality { get; set; }
        public List<League>? Leagues { get; set; }
        public List<Player>? Players { get; set; }
    }
}
