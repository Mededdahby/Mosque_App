using Microsoft.AspNetCore.Mvc;
using MuslimApp.Data.Services;
using MuslimApp.Models;

namespace MuslimApp.Controllers
{
    public class MosquesController : Controller
    {
        private readonly IMosqueService _service;

        public MosquesController(IMosqueService service)
        {
            _service = service;
        }




        // GET: MosquesController
        public async Task<IActionResult> Index()
        {
            var allmosques = await _service.GetAllAsync();
            return View(allmosques);
        }

        // Searching Action
        public async Task<IActionResult> Filter(string searchString)
        {
            var allmosques = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResualt = allmosques.Where(x => x.mosqueName.Contains(searchString) || x.mosqueInformation.Contains(searchString) || x.mosqueLocation.Contains(searchString)).ToList();
                return View("Index" , filterResualt);
            }
            return View("Index" , allmosques);
        }
        // GET: MosquesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var mosquedetails = await _service.GetByIdAsync(id);
            if (mosquedetails == null) return View("NotFound");

            return View(mosquedetails);
        }

        // GET: MosquesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MosquesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("mosquePicture,mosqueName,mosqueLocation,mosqueInformation,situation")] mosque mosque)
        {


            await _service.AddAsync(mosque);
            return RedirectToAction(nameof(Index));
        }



        // GET: MosquesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var mosquedetails = await _service.GetByIdAsync(id);
            if (mosquedetails == null) return View("Notfound");

            return View(mosquedetails);
        }

        // POST: MosquesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int mosqueId, [Bind("mosqueId ,mosquePicture,mosqueName,mosqueLocation,mosqueInformation,situation")] mosque mosque)
        {
            await _service.UpdateAsync(mosqueId, mosque);
            return RedirectToAction(nameof(Index));
        }

        // GET: MosquesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var mosquedetails = await _service.GetByIdAsync(id);
            if (mosquedetails == null) return View("Notfound");

            return View(mosquedetails);
        }

        // POST: MosquesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mosquedetails = await _service.GetByIdAsync(id);
            if (mosquedetails == null) return View("Notfound");
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

