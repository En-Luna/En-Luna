using En_Luna.Areas.Admin.Models;
using En_Luna.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace En_Luna.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Errors(result);
                }
            }

            return View(name);
        }
        public async Task<IActionResult> Update(string id)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                return RedirectToAction("Index");
            }

            List<User> members = new List<User>();
            List<User> nonMembers = new List<User>();

            foreach (User user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) 
                    ? members 
                    : nonMembers;

                list.Add(user);
            }

            return View(new RoleEditViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    User? user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            Errors(result);
                        }
                    }
                }

                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    User? user = await _userManager.FindByIdAsync(userId);

                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                        {
                            Errors(result);
                        }
                    }
                }
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return await Update(model.RoleId);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole? role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    Errors(result);
                }
            }
            else
            { 
                ModelState.AddModelError("", "No role found");
            }

            return View("Index", _roleManager.Roles);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors) 
            {
                ModelState.AddModelError("", error.Description);
            }
        }
    }
}
