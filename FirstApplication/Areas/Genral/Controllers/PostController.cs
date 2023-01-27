using AutoMapper;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using FirstApplication.Models;
using FirstApplication.UploadFile;
using Microsoft.AspNetCore.Http;
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
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IMapper _mapper;
        private readonly JobsContext db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(ILogger<PostController> logger, IMapper mapper, JobsContext jobsContext, IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            this._logger = logger;
            this._mapper = mapper;
            this.db = jobsContext;
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
        }

        public IActionResult Allposts()
        {
            ViewBag.Feelings = _unitOfWork.FeelingsReprositry.GetAll().ToList();
            ViewBag.Posts = _unitOfWork.PostsReprositry.GetAll().ToList();
            //var Posts = _unitOfWork.PostsReprositry.GetAll().ToList();
            //var result = _mapper.Map<IEnumerable<Post>, IEnumerable<PostVm>>(Posts);
            return View();
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            ViewBag.Feelings = _unitOfWork.FeelingsReprositry.GetAll().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(PostVm postVm, IFormFile image)
        {
            if (image != null)
            {
                postVm.Image = UploadFiles.UploadFile(image);
            }
            postVm.UserId = _userManager.GetUserId(User);
            
                var data = _mapper.Map<Post>(postVm);
                _unitOfWork.PostsReprositry.Insert(data);
                _unitOfWork.SaveChanges();
                return RedirectToAction("AllPosts", "Post");

        }
        
        [HttpGet]
        public IActionResult EditPost(int Id)
        {
            if (Id == null)
            {
                return PartialView("_error");
            }
            if (_unitOfWork.PostsReprositry.GetById(Id) == null)
            {
                return NotFound();
            }
            ViewBag.Feelings = _unitOfWork.FeelingsReprositry.GetAll().ToList();

            var post = _unitOfWork.PostsReprositry.GetById(Id);
            var PostData = _mapper.Map<PostVm>(post);
            return View(PostData);
            //return PartialView("_error");
        }
        [HttpPost]
        public IActionResult EditPost(PostVm postVm, IFormFile Image)
        {
            var Userid = _userManager.GetUserId(User);
            postVm.UserId = Userid;
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    postVm.Image = UploadFiles.UploadFile(Image);
                }
                //postVm.FeelingId = 2;
                var PostData = _mapper.Map<Post>(postVm);
                _unitOfWork.PostsReprositry.Update(PostData);
                _unitOfWork.SaveChanges();
                return RedirectToAction("AllPosts", "Post", new { area = "Genral" });
            }
            return View(postVm);
        }

        public JsonResult DeletePost(int id)
        {
            //var DeletedPost = _unitOfWork.PostsReprositry.GetById(Id);
            _unitOfWork.PostsReprositry.Delete(id);
            //var c = db.post.Find(Id);
            //db.post.Remove(c);
            _unitOfWork.SaveChanges();
            return Json("sucess");
        }
    }
}
