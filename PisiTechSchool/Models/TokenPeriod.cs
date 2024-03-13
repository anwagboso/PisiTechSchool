using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PisiTechSchool.Models
{
    public class TokenPeriod
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int ExpiryPeriod { get; set; }

        public string? Description { get; set; }

    }
}
