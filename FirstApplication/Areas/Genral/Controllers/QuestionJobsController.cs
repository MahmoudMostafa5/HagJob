using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstApplication.DB;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.Models;

namespace FirstApplication.Areas.Genral.Controllers
{
    [Area("Genral")]
    public class QuestionJobsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly JobsContext db;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly ILogger<QuestionJobsController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionJobsController(
            ILogger<QuestionJobsController> logger,
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
        public IActionResult AllQuestionOfMyUploadJob()
        {
            var UserId = _UserManager.GetUserId(User);
            var CurrentQuestions = _unitOfWork.QUestionsJobReprositry.GetAll().Where(s => s.jobs.UserId == UserId).ToList();
            var Data = _mapper.Map<IEnumerable<QuestionJob>, IEnumerable<QuestionJobVm>>(CurrentQuestions);
            return View(Data);
        }
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var QuestionData = _unitOfWork.QuestionReprositryMethods.GetQuestionJob(id);
            if (QuestionData == null)
            {
                return NotFound();
            }
            var CurrentData = _mapper.Map<QuestionJobVm>(QuestionData);
            return View(CurrentData);
        }
        public IActionResult Create(int id)
        {
            TempData["Name"] = _unitOfWork.JobReprositry.GetById(id).Name;
            TempData["IdCreate"] = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QuestionJob questionJob)
        {
            int IdJob = Convert.ToInt32(TempData["IdCreate"]);
            questionJob.Job_Id = IdJob;
            if (ModelState.IsValid)
            {
                var Data = _mapper.Map<QuestionJob>(questionJob);
                _unitOfWork.QUestionsJobReprositry.Insert(Data);
                _unitOfWork.SaveChanges();
                return RedirectToAction("ViewMyUploadJob","Jobs" ,new { area = "Admin"});
            }
            return View(questionJob);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TempData["IdEdit"] = id;
            var questionJob =  _unitOfWork.QUestionsJobReprositry.GetById(id);
            if (questionJob == null)
            {
                return NotFound();
            }
            var Data = _mapper.Map<QuestionJobVm>(questionJob);
            TempData["Name"] = _unitOfWork.QuestionReprositryMethods.GetQuestionJob(id).jobs.Name;
            return View(Data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(QuestionJobVm questionJobVm)
        {
            int jobId = Convert.ToInt32(TempData["IdEdit"]);
            questionJobVm.Job_Id=jobId;
            if (ModelState.IsValid)
            {
                var Data = _mapper.Map<QuestionJob>(questionJobVm);
                _unitOfWork.QUestionsJobReprositry.Update(Data);
                _unitOfWork.SaveChanges();
                return RedirectToAction("AllQuestionOfMyUploadJob");
            }
            return View(questionJobVm);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CurentQuestions = _unitOfWork.QUestionsJobReprositry.GetById(id);
            if (CurentQuestions == null)
            {
                return NotFound();
            }
            else
            {
                _unitOfWork.QUestionsJobReprositry.Delete(id);
                _unitOfWork.SaveChanges();
                return RedirectToAction("AllQuestionOfMyUploadJob");
            }
        }
    }
}
