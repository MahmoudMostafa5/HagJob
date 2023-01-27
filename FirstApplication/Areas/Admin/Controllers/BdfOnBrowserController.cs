using AutoMapper;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
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

    public class BdfOnBrowserController : Controller
    {
        private readonly ILogger<UserInformationController> _Logger;
        private readonly IUnitOfWork _Unit;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _Usermanager;
        public BdfOnBrowserController(
            ILogger<UserInformationController> Log
            , IUnitOfWork un,
            IMapper map,
            UserManager<ApplicationUser> user)
        {
            this._Unit = un;
            this._Logger = Log;
            this._mapper = map;
            this._Usermanager = user;
        }
        public ActionResult Index()
        {
            return RedirectToAction("OpenPDF");
        }
        public FileResult OpenPDF()
        {
            string CurrentUserId = _Usermanager.GetUserId(User);
            var CurrentUser = _Unit.UserInformationReprositry.GetById(CurrentUserId);
            string PDFpath = "wwwroot/ImageProfile/" + CurrentUser.CV;
            byte[] abc = System.IO.File.ReadAllBytes(PDFpath);
            System.IO.File.WriteAllBytes(PDFpath, abc);
            MemoryStream ms = new MemoryStream(abc);
            return new FileStreamResult(ms, "application/pdf");

        }
        public FileResult DownloadFile()
        {
            var UserId = _Usermanager.GetUserId(User);
            var CurrentUserInformation = _Unit.UserInformationReprositry.GetById(UserId);
            string PDFpath = "wwwroot/ImageProfile/" + CurrentUserInformation.CV;
            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(PDFpath);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", CurrentUserInformation.CV);
        }
    }
}
