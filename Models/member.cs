using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Linq;
using MuslimApp.Data.Enums;

namespace MuslimApp.Models
{
    public class member
    {
        [Key]
        public int memberID { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string memberName { get; set; }
        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required")]
        public role role { get; set; }
        public int mosqueId { get; set; }
        [ForeignKey("mosqueId")]
        public mosque mosque { get; set; }
    }
}
