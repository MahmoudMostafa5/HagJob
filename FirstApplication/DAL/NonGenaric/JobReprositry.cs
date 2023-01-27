using AutoMapper;
using Microsoft.Extensions.Logging;
using FirstApplication.DAL.GenaricRepo;
using FirstApplication.DB;
using FirstApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DAL.NonGenaric
{
    public class JobReprositry : GenericRepository<jobs>, IJobReprositry
    {
        public JobReprositry(JobsContext context ) : base(context )
        {
        }
        public IEnumerable<jobs> GetMyJobUploaded(string UserId)
        {
            return _context.jobs.Where(s=>s.UserId==UserId&&s.Statues==true).Include(s=>s.Dep).ToList();

        }

  
    }
}
