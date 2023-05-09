using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolSystem.ViewModels;

namespace SchoolSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AddRoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AddRoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create( RoleViewModel VM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = VM.RoleName;
                IdentityResult result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return View();
                else
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
            }
           
            return View(VM);
        }

    }
}
