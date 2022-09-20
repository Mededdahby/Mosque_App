using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimApp.Data.Services;
using MuslimApp.Models;

namespace MuslimApp.Controllers
{
    public class DonationsController : Controller
    {
        private readonly IDonnationService _service;


        public DonationsController(IDonnationService service)
        {
            _service = service; 
        }
      






        // GET: MosquesController
        public async Task<IActionResult> Index()
        {
            var all = await _service.GetAllAsync();
            return View(all);
        }

        // GET: MosquesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var donationifo = await _service.GetByIdAsync(id);
            if (donationifo == null) return View("NotFound");

            return View(donationifo);
        }

        // GET: MosquesController/Create
        public async Task<IActionResult> Create()
        {
            var DonationsDropDownData = await _service.GetDonationsdropDownValues();
            ViewBag.mosqueId = new SelectList(DonationsDropDownData.Mosques, "mosqueId", "mosqueName");
           
            return View();
        }

        // POST: MosquesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name , Amount , Description ,mosqueId")] Donation donation)
        {
            await _service.AddAsync(donation);
            return RedirectToAction(nameof(Index));

        }



        // GET: MosquesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var donationifo = await _service.GetByIdAsync(id);
            if (donationifo == null) return View("Notfound");
            //DropDownList
            var DonationsDropDownData = await _service.GetDonationsdropDownValues();
            ViewBag.mosqueId = new SelectList(DonationsDropDownData.Mosques, "mosqueId", "mosqueName");

            return View(donationifo);
        }

        // POST: MosquesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Donation donation)
        {
            await _service.UpdateAsync(Id, donation);
            return RedirectToAction(nameof(Index));
        }


        // GET: MosquesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var donationifo = await _service.GetByIdAsync(id);
            if (donationifo == null) return View("Notfound");

            return View(donationifo);
        }

        // POST: MosquesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donationifo = await _service.GetByIdAsync(id);
            if (donationifo == null) return View("Notfound");
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));

        }

        /*
public override bool Equals(object obj)
        {
            return obj is MosquesController controller &&
                   EqualityComparer<ApplicationDbContext>.Default.Equals(_service, controller._service);
        }
        */
        public override int GetHashCode()
        {
            return HashCode.Combine(_service);
        }
    }
}
