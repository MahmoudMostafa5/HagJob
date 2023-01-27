using AutoMapper;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using FirstApplication.Models;
using FirstApplication.UploadFile;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JobsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly JobsContext db;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly ILogger<JobsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public JobsController(
            ILogger<JobsController> logger,
            IMapper map ,
            JobsContext j,
            IUnitOfWork unitOfWork , 
            UserManager<ApplicationUser> user)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            this._mapper = map;
            this.db = j;
            this._UserManager = user;
        }
        public IActionResult Index()
        {

            ViewBag.job = _unitOfWork.JobReprositry.GetAll().OrderByDescending(x => x.Date).ToList();
            var DepartmentVm = _unitOfWork.DepartmentReprositry.GetAll().ToList();
            var result = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentVM>>(DepartmentVm);
            return View(result);
        }
        [HttpGet]
        public IActionResult ViewAllJobs(int id)
        {
            var data = _unitOfWork.JobReprositry.GetAll().Where(x => x.DepId == id).OrderByDescending(x => x.Date).ToList();
            var result = _mapper.Map<IEnumerable<jobs>, IEnumerable<JobVm>>(data);
            return View(data);
        }
        [HttpGet]
        public IActionResult CreateJob()
        {
            ViewBag.DepartmentList = _unitOfWork.DepartmentReprositry.GetAll().ToList();
            ViewBag.userId = _UserManager.GetUserId(User);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateJob(JobVm jobVm , IFormFile photo)
        {
            jobVm.Image = UploadFiles.UploadFile(photo);
            jobVm.Date = DateTime.Now;
            jobVm.UserId = _UserManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                var data = _mapper.Map<jobs>(jobVm);
                data.DepId = jobVm.DepId;
                _unitOfWork.JobReprositry.Insert(data);
                _unitOfWork.SaveChanges();
                return RedirectToAction("Create", "QuestionJobs", new {area="Genral" ,id=data.Job_Id  });
            }

            ViewBag.DepartmentList = _unitOfWork.DepartmentReprositry.GetAll().ToList();
            return View(jobVm);
        }
         public IActionResult ViewMyUploadJob()
        {
            var UserId = _UserManager.GetUserId(User);
            IEnumerable<jobs> CurrentJob = _unitOfWork.JobrepoMethods.GetMyJobUploaded(UserId);
            var  data = _mapper.Map<IEnumerable<jobs>, IEnumerable<JobVm>>(CurrentJob);
            return View(data);
        }
        public IActionResult Update(int id)
        {
            ViewBag.DepartmentList = _unitOfWork.DepartmentReprositry.GetAll().ToList();
            var CurrentJob = _unitOfWork.JobReprositry.GetById(id);
            var Data = _mapper.Map<JobVm>(CurrentJob);
            return View(Data);
        }
        [HttpPost]
        public IActionResult Update(JobVm jobVm , IFormFile photo)
        {
            jobVm.Image =UploadFiles.UploadFile(photo);
            jobVm.Date = DateTime.Now;
            jobVm.UserId = _UserManager.GetUserId(User);
            if (ModelState.IsValid)
            {
                var Data = _mapper.Map<jobs>(jobVm);
                _unitOfWork.JobReprositry.Update(Data);
                _unitOfWork.SaveChanges();
                return RedirectToAction("ViewMyUploadJob");
            }
            ViewBag.DepartmentList = _unitOfWork.DepartmentReprositry.GetAll().ToList();
            
            return View(jobVm);
        }
        public IActionResult Details(int id)
        {
            var CurentJob = _unitOfWork.JobReprositry.GetById(id);
            var Data = _mapper.Map<JobVm>(CurentJob);
            return View(Data);
        }
        public IActionResult BlockApply(int id)
        {
            var CurrentJob = _unitOfWork.JobReprositry.GetById(id);
            CurrentJob.Statues = false;
            _unitOfWork.SaveChanges();
            return RedirectToAction("ViewMyUploadJob");
        }
        public IActionResult Delete(int id)
        {
            _unitOfWork.JobReprositry.Delete(id);
            _unitOfWork.SaveChanges();
            return RedirectToAction("ViewMyUploadJob");
        }
    }
}
