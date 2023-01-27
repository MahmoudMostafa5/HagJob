using FirstApplication.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApplication.Models;

namespace FirstApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AspUserRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AspUserRolesController(UserManager<ApplicationUser> UserManage, RoleManager<IdentityRole> Role)
        {
            this._UserManager = UserManage;
            this._roleManager = Role;
        }
        [HttpGet]
        public IActionResult CreateUserRoles()
        {
            var Roles = _roleManager.Roles.ToList();
            ViewBag.Roles = Roles;
            ViewBag.Users = _UserManager.Users.ToList();
            return View();
        }
        [HttpPost]
        //Admin/AspUserRoles/CreateUserRoles
        public async Task<IActionResult> CreateUserRoles(AspUserRoles model)
        {
            var UserEmail =await _UserManager.FindByIdAsync(model.UserId);
            var RoleName = await _roleManager.FindByIdAsync(model.RoleId);
            //var result = await _UserManager.AddToRoleAsync(model.UserId, model.RoleId);

            return Content("Email" + UserEmail + " /**/ " + RoleName.Id);
        }
    }

               
}
