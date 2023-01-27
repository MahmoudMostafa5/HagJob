using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using FirstApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FirstApplication.MailHeleper;

namespace FirstApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUnitOfWork _unit;
        private readonly ILogger<AccountController> _loger;
        public AccountController(
                   UserManager<ApplicationUser> userManager,
                   SignInManager<ApplicationUser> signInManager ,
                   ILogger<AccountController> Logger,
                   IUnitOfWork unit)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._unit = unit;
            this._loger = Logger;
        }
        [HttpGet]
        public IActionResult ResetPassword(string Email , string Token)
        {
            if(Email==null || Token == null)
            {
                return Content("Invalid Info");
            }
            else
            {
                var model = new ResetPassword { Token = Token, Email = Email };
                return View(model);
            }

        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword resetPasswordmodel)
        {
            var User = await _userManager.FindByEmailAsync(resetPasswordmodel.Email);
            if (User != null)
            {
                var Result = await _userManager.ResetPasswordAsync(User, resetPasswordmodel.Token, resetPasswordmodel.Password);
                

                if (Result.Succeeded)
                {
                    return RedirectToAction("ConfirmResetPassword");
                }
                else
                {
                    return Content("THere Was An Erorr");
                }
            }
            else
            {
                return Content("There was An Erorr");
            }

        }
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPassword forgetPasswordmodel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordmodel.Email);

            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = forgetPasswordmodel.Email, Token = token }, Request.Scheme);
                MailHeleper.MailHelper.sendMail("Password Reset Link", passwordResetLink);

                _loger.Log(LogLevel.Warning, passwordResetLink);

                return RedirectToAction("ConfirmForgetPassword");
            }
            else
            {

                return View();
            }
        }

        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {
            return View();

        }

        [HttpGet]
        public IActionResult Login()
        {
            return  View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(Login loginmodel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginmodel.Email);
                {
                    //sign in
                    if (user == null)
                    {
                        ViewBag.Message = "Invalid Input";
                        return View();
                    }
                    else
                    {
                        var Result = await _signInManager.PasswordSignInAsync
                                       (user, loginmodel.PassWord, loginmodel.RemmemberMe, false);

                        if (Result.Succeeded)
                        {
                            return RedirectToAction("AddInformationToUser", "UserInformation", new { area = "Admin"} );
                        }
                        else
                        {
                            ViewBag.Message = "Invalid Input";
                            return View();
                        }
                    }
                    
                }
            }
            else
            {
                ViewBag.Message = "Invalid Input";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var UsersType = _unit.usertypeReprositry.GetAll().ToList();
            ViewBag.cities = UsersType;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register Register)
        {
            if (ModelState.IsValid)
            {
                var UserData = new ApplicationUser()
                {
                    UserName = Register.UserName,
                    Email = Register.Email,
                    UserTypeId = Register.UserType
                };
                var result = await _userManager.CreateAsync(UserData, Register.PassWord);
                if (result.Succeeded)
                {
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(UserData);
                    var confirmationLink = Url.Action("ConfirmEmail", "Account", new { token, email = UserData.Email }, Request.Scheme);
                    MailHeleper.MailHelper.sendMail("Confirm Yor Email", confirmationLink);
                    _loger.Log(LogLevel.Warning, confirmationLink);
                    return RedirectToAction("CreateUserRoles","AspUserRoles" , new { area="Admin" , email = UserData.Email});
                }
                else
                {
                    ViewBag.Message = "Inavlid Input";
                    var TypeUser = _unit.usertypeReprositry.GetAll().ToList();
                    ViewBag.cities = TypeUser;
                    return View();
                }
            }
            ViewBag.Message = "Inavlid Input";
            var UsersType = _unit.usertypeReprositry.GetAll().ToList();
            ViewBag.cities = UsersType;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string email , string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return Content("Please Register Again");
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }
            else
            {
                return Content("Confirm Email Failed");
            }
        }
        [HttpGet]
        public IActionResult SuccesRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
             await _signInManager.SignOutAsync();
            return RedirectToAction("Login");

        }
    }
}
