using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PisiTechSchool.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ServiceId { get; set; }
        

        [Required]
        public string Email { get; set; }
        

        [Required]
        [StringLength(11, MinimumLength = 7)]
        public string PhoneNumber { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

       

     
    }
}
