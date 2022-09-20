using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuslimApp.Models;

namespace MuslimApp.Controllers
{
    public class AdministrationController : Controller
    {

        private readonly RoleManager<IdentityRole> roleManager;
        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //Create : GET
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole( RolesCreate model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole()
                {
                    Name = model.roleName

                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index" , "Home");
                }
                foreach(IdentityError error  in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
