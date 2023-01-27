using FirstApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AspRolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AspRolesController(RoleManager<IdentityRole> user)
        {
            this._roleManager = user;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var Roles = _roleManager.Roles.ToList();
            return View(Roles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleVm model)
        {
            if (ModelState.IsValid)
            {
                var Role = new IdentityRole()
                {
                    Name = model.RoleName
                };
                var Result = await _roleManager.CreateAsync(Role);
                if (Result.Succeeded)
                {
                    return RedirectToAction("CreateRole");
                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edite(string Id )
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var data = new EditeRole()
            {
                Id = role.Id,
                RoleName = role.Name
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Edite(EditeRole editeModel)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(editeModel.Id);
                role.Name = editeModel.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
                return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string Id) 
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var data = new DeleteRole()
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(data);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteRole deletemodel)
        {
            var role =await _roleManager.FindByIdAsync(deletemodel.Id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var role = await _roleManager.FindByIdAsync(Id);
            var data = new DetailsRoel()
            {
                Id = role.Id,
                Name = role.Name,
                Normalization = role.NormalizedName,
                CouncerencyStamp = role.ConcurrencyStamp
            };
            if (role != null)
            {
                return View(data);
            }
            else
            {
                return Content("Error");
            }
        }
    }
}
