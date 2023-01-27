using AutoMapper;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using FirstApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Areas.Genral.Controllers
{
    [Area("Genral")]
    public class ApplyJobsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly JobsContext db;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly ILogger<ApplyJobsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ApplyJobsController(
            ILogger<ApplyJobsController> logger,
            IMapper map,
            JobsContext j,
            IUnitOfWork unitOfWork,
            UserManager<ApplicationUser> user)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            this._mapper = map;
            this.db = j;
            this._UserManager = user;
        }
        public IActionResult ViewJob()
        {
            return View();
        }
        public IActionResult Apply(int id)
        {
            var UserInformation = _unitOfWork.UserInformationReprositry.GetById(User);
            var UserAdress = _unitOfWork.UserInformationReprositry.GetById(User);
            ViewBag.userAdress = _mapper.Map<AdressUserVM>(UserAdress);
            ViewBag.userInformation = _mapper.Map<UserInformationVm>(UserInformation);
            return View();
        }
    }
}
