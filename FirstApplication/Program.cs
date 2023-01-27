using AutoMapper;
using FirstApplication.DAL.UniteOfWork;
using FirstApplication.DB;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication
{
    public class Program
    {
        private readonly IMapper _mapper;
        private readonly JobsContext db;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly ILogger<Program> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public Program(
            ILogger<Program> logger,
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
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        // For Delete All Jobs With Statues Falsse
        //public  void DeleteAllJobOfFalseStatues()
        //{
        //    var AllJobs = _unitOfWork.JobReprositry.GetAll().ToList();
        //    foreach (var item in AllJobs)
        //    {
        //        if (item.Statues == false)
        //        {
        //            _unitOfWork.JobReprositry.Delete(item);
        //            _unitOfWork.SaveChanges();
        //        }
        //    }
        //}
    }
}
