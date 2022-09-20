using MuslimApp.Models;

namespace MuslimApp.Data.viewmodel
{
    public class membersdropdown
    {
        public membersdropdown()
        {
            Mosques = new List<mosque>();
        }
        public List<mosque>  Mosques { get; set; }
    }
}
