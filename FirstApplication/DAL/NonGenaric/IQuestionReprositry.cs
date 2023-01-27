using FirstApplication.DAL.GenaricRepo;
using FirstApplication.DB;
using FirstApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DAL.NonGenaric
{
    public interface IQuestionReprositry : IGenericRepository<QuestionJob>
    {
        QuestionJob GetQuestionJob(int id);
    }
}
