using System.ComponentModel.DataAnnotations;

namespace EFPundit.Models
{
    public  class League
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Club>? Clubs { get; set; }

        public Country? Country { get; set; }
    }
}
