using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using FirstApplication.Models;

namespace FirstApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserAdressingController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly ILogger<UserAdressingController> _Logger;

        public UserAdressingController(IUnitOfWork un ,
            IMapper map ,
            UserManager<ApplicationUser> user ,
            ILogger<UserAdressingController> log)
        {
            this._unit = un;
            this._mapper = map;
            this._usermanager = user;
            this._Logger = log;

        }
        [HttpGet]
        public IActionResult AddAdressToUser()
        {
            var CurrentUserId = _usermanager.GetUserId(User);
            var CurrentUser = _unit.AdreesReprositry.GetById(CurrentUserId);
            if (CurrentUser == null)
            {
                ViewBag.currentUserId = _usermanager.GetUserId(User);
                return View();
            }
            else
            {
                return RedirectToAction("profile", "UserInformation", new { area = "Admin" });
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddAdressToUser(AdressUserVM AdressModel)
        {
            if (ModelState.IsValid)
            {
                AdressModel.UserId = _usermanager.GetUserId(User);
                var UserAdressdata = _mapper.Map<Adresss>(AdressModel);
                _unit.AdreesReprositry.Insert(UserAdressdata);
                _unit.SaveChangeAsyn();
                return RedirectToAction("Create", "AspRoles", new { area = "Admin" });
            }
            else
            {
                return Content("There Were Some Error in the data that was passed");
            }
            
        }
    }
}
