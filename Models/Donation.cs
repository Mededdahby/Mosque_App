using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MuslimApp.Models
{
    public class Donation
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }
        [Display(Name = "Amount")]
        [Required(ErrorMessage = "Amount is required")]
        [Range(1, double.MaxValue, ErrorMessage = "Awrak ikhlf rbbi Aya9mach amoxom {1}")]
        
        public double Amount { get; set; }
        [Display(Name = "Descrption")]
        [Required(ErrorMessage = "Descrption is required")]
        public string Description { get; set; }
        public int mosqueId { get; set; }
        [ForeignKey("mosqueId")]
        public mosque mosque { get; set; }
    }
}