using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MuslimApp.Data.Services;
using MuslimApp.Models;

namespace MuslimApp.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberService _service;

       
        public MembersController(IMemberService service)
        {
            _service = service;
        }


    



        // GET: MosquesController
        public async Task<IActionResult> Index()
        {
            var allmembers = await _service.GetAllAsync();
            return View(allmembers);
        }
        // Searching Action
        public async Task<IActionResult> Filter2(string searchString)
        {
            var allmosques = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
             
                var filterResualt = allmosques.Where(y => y.memberName.Contains(searchString) || y.mosque.mosqueName.Contains(searchString)).ToList();
                return View("Index", filterResualt);
               
            
            }
            return View("Index", allmosques);
        }

        // GET: MosquesController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var memberdetails = await _service.GetByIdAsync(id);
            if (memberdetails == null) return View("NotFound");

            return View(memberdetails);
        }

        // GET: MosquesController/Create
        public async Task<IActionResult> Create()
        {
            var memberdropdowndata = await _service.GetMembersdropdownValues();
            ViewBag.mosqueId = new SelectList(memberdropdowndata.Mosques, "mosqueId", "mosqueName");
            return View();    
        }

        // POST: MosquesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("memberName ,role ,mosqueId")] member member)
        {
            await _service.AddAsync(member);
            return RedirectToAction(nameof(Index));

        }



        // GET: MosquesController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var memberdetails = await _service.GetByIdAsync(id);
            if (memberdetails == null) return View("Notfound");
            var memberdropdowndata = await _service.GetMembersdropdownValues();
            ViewBag.mosqueId = new SelectList(memberdropdowndata.Mosques, "mosqueId", "mosqueName");

            return View(memberdetails);
        }

        // POST: MosquesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int memberID,  member member)
        {
            await _service.UpdateAsync(memberID, member);
            return RedirectToAction(nameof(Index));
        }

        // GET: MosquesController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var memberdetails = await _service.GetByIdAsync(id);
            if (memberdetails == null) return View("Notfound");

            return View(memberdetails);
        }

        // POST: MosquesController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var memberdetails = await _service.GetByIdAsync(id);
            if (memberdetails == null) return View("Notfound");
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
