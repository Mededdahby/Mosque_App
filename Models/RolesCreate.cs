using MuslimApp.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace MuslimApp.Models
{
    public class RolesCreate
    {
        [Display(Name="Role" )]
        public string roleName { get; set; }
    }
}
