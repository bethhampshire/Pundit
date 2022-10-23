using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public class Season
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Year { get; set; }
        public bool Current { get; set; }
        public PlayerStats? PlayerStats { get; set; }
    }
}
