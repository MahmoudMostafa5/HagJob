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
    public class QuestionReprositry : GenericRepository<QuestionJob> , IQuestionReprositry
    {
        public QuestionReprositry(JobsContext context) : base(context)
        {
        }
        public QuestionJob GetQuestionJob(int id)
        {
            var CurrentRecord = _context.questions.Where(s => s.Job_Id == id).Include(s => s.jobs).FirstOrDefault();
            return CurrentRecord;
        }


    }
}
