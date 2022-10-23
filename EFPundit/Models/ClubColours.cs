using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public class ClubColours
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Club Club { get; set; }
        public string? PrimaryHex { get; set; }
        public string? SecondaryHex { get; set; }
        public string? TertiaryHex { get; set; }
    }
}
