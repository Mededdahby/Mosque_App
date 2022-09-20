using MuslimApp.Models;

namespace MuslimApp.Data.viewmodel
{
    public class DonationsdropDown
    {
        public DonationsdropDown()
        {
            Mosques = new List<mosque>();
        }
        public List<mosque> Mosques { get; set; }
    }
}

