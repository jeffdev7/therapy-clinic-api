using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace clinic.MVC.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IdentityRole role)
        {
            if (!_roleManager.RoleExistsAsync(role.Name!).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(role.Name!)).GetAwaiter().GetResult();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
