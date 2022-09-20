using MuslimApp.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace MuslimApp.Models
{
    public class mosque
    {
       [ Key]
        public int mosqueId { get; set; }
        [Display(Name = "Picture URL")]
        [Required(ErrorMessage = "Picture URL is required")]
        [DataType((DataType.ImageUrl))]
        public string mosquePicture { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string mosqueName { get; set; }
        [Display(Name = "Location")]
        [Required(ErrorMessage = "Location is required")]
        public string mosqueLocation { get; set; }
        [Display(Name = "Informations About")]
        [Required(ErrorMessage = "Informations are required")]
        public string mosqueInformation { get; set; }
        [Required(ErrorMessage = "choe Situation required")]
        public situation situation { get; set; }

        //RelationSheps
        public List<member> members { get; set; }
        public List<Donation> donations { get; set; }
    }
}
