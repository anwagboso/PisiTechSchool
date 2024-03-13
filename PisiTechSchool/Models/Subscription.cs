using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PisiTechSchool.Models
{
    public class Subscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionId { get; set; }

        [Required]
        public int ServiceId { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 7)]
        public string PhoneNumber { get; set; }
        
        [Required]
        public DateTime SubscribedDate { get; set; }

        
    }
}
