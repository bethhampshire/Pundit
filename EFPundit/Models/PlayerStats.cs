using EFPundit.Enums;
using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public class PlayerStats
    {
        [Key]
        public int Id { get; set; }
        public Season? Season { get; set; }
        public Player? Player { get; set; }
        public Club? Club { get; set; }
        public GameTypes GameTypes { get; set; }
        public int? Goals { get; set; }
        public int?  Assists { get; set; }
        public int? YellowCards { get; set; }
        public int? RedCards { get; set; }
        public int? Cleansheets { get; set; }
        public int? MinutesPlayed { get; set; }
        public int? Appearances { get; set; }
    }
}
