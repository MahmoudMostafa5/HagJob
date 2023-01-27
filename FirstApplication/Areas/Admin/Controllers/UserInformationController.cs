using AutoMapper;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using FirstApplication.Models;
using FirstApplication.UploadFile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize]
    public class UserInformationController : Controller
    {
       private readonly ILogger<UserInformationController> _Logger;
        private readonly IUnitOfWork _Unit;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _Usermanager;

        // 1 -  Constractor 
        // 2 -  Dependancy Injection 
        // 3 -  CRUD Operation
        public UserInformationController(
            ILogger<UserInformationController> Log 
            , IUnitOfWork un ,
            IMapper map ,
            UserManager<ApplicationUser> user)
        {
            this._Unit = un;
            this._Logger = Log;
            this._mapper = map;
            this._Usermanager = user;
        }

        //add information to user
        [HttpGet]
        public IActionResult AddInformationToUser()
        {
            var CurrentUserId = _Usermanager.GetUserId(User);
            var CurrentUser = _Unit.UserInformationReprositry.GetById(CurrentUserId);
            if (CurrentUser == null)
            {
                ViewBag.currentUserId = _Usermanager.GetUserId(User);
                return View();
            }
            else
            {
                return RedirectToAction("AddAdressToUser" , "UserAdressing" , new { area ="Admin"});
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddInformationToUser(UserInformationVm uservmModel , IFormFile Image , IFormFile Cv)
        {
            uservmModel.UserId = _Usermanager.GetUserId(User);
            uservmModel.Photo = UploadFiles.UploadFile(Image);
            uservmModel.CV = UploadFiles.UploadFile(Cv);
            var UserData = _mapper.Map<UserInformation>(uservmModel);
            _Unit.UserInformationReprositry.Insert(UserData);
            _Unit.SaveChanges();
            return Content("Done");
        }

        //updte user information
        [HttpGet]
        public IActionResult UpdateInformation()
        {
            var CurrentUserId = _Usermanager.GetUserId(User);

            UserInformation CurrentUserInformartion = _Unit.UserInformationReprositry.GetById(CurrentUserId);
            var UserData = _mapper.Map<UserInformationVm>(CurrentUserInformartion);

            return View(UserData);
        }
        [HttpPost]
        public IActionResult UpdateInformation(UserInformationVm userInformationVm , IFormFile CV , IFormFile Photo)
        {
            if (ModelState.IsValid)
            {
                var CurrentUserId = _Usermanager.GetUserId(User);
                userInformationVm.CV = UploadFiles.UploadFile(CV);
                userInformationVm.Photo = UploadFiles.UploadFile(Photo);
                // To mapp between Userinformation from database with userinformation Vm in the model(passing)
                var UserData = _mapper.Map<UserInformation>(userInformationVm);
                _Unit.UserInformationReprositry.Update(UserData);
                _Unit.SaveChanges();
                return RedirectToAction("profile", "UserInformation", new { area = "Admin" });
            }
            return View(userInformationVm);
        }

        //updte user address
        [HttpGet]
        public IActionResult UpdateUserAddress()
        {
            var CurrentUserId = _Usermanager.GetUserId(User);
            Adresss CureentUserAdresss = _Unit.AdreesReprositry.GetById(CurrentUserId);
            var UserAddress = _mapper.Map<AdressUserVM>(CureentUserAdresss);
            return View(UserAddress);
        }
        [HttpPost]
        public IActionResult UpdateUserAddress(AdressUserVM adressUserVM)
        {
            if (ModelState.IsValid)
            {
                adressUserVM.UserId = _Usermanager.GetUserId(User);
                var UserAddress = _mapper.Map<Adresss>(adressUserVM);
                _Unit.AdreesReprositry.Update(UserAddress);
                _Unit.SaveChanges();
                return RedirectToAction("profile", "UserInformation", new { area = "Admin" });
            }
            return View(adressUserVM);
        }

        public IActionResult Profile()
        {
            var CurrentUserId = _Usermanager.GetUserId(User);
            var CurrentUser = _Unit.AdreesReprositry.GetById(CurrentUserId);

            ViewBag.userInformation = _Unit.UserInformationReprositry.GetById(CurrentUserId);
            ViewBag.userAdress = CurrentUser;
            ViewBag.UserId = CurrentUserId;

            return View();
        }
        public ActionResult UpdateMyCv(IFormFile MyCv)
        {
            var UserId = _Usermanager.GetUserId(User);
            var CurrentUserInformation = _Unit.UserInformationReprositry.GetById(UserId);
            CurrentUserInformation.CV = UploadFiles.UploadFile(MyCv);
            _Unit.SaveChanges();
            return RedirectToAction("Profile");
        }
        public ActionResult UpdateMyPhoto(IFormFile MyPhoto)
        {
            var UserId = _Usermanager.GetUserId(User);
            var CurrentUserInformation = _Unit.UserInformationReprositry.GetById(UserId);
            CurrentUserInformation.Photo = UploadFiles.UploadFile(MyPhoto);
            _Unit.SaveChanges();
            return RedirectToAction("Profile");
        }
    }
    }

