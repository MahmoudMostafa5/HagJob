using FirstApplication.DAL.GenaricRepo;
using FirstApplication.DAL.NonGenaric;
using FirstApplication.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DAL.UniteOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<jobs> JobReprositry { get; }
        IGenericRepository<UserType> usertypeReprositry { get; }
        IGenericRepository<UserInformation> UserInformationReprositry { get; }
        IGenericRepository<Adresss> AdreesReprositry { get; }
        IGenericRepository<Department> DepartmentReprositry { get; }
        IGenericRepository<QuestionJob> QUestionsJobReprositry { get; }
        IJobReprositry JobrepoMethods { get; }
        IQuestionReprositry QuestionReprositryMethods { get; }

        IGenericRepository<Post> PostsReprositry { get; }
        IGenericRepository<Feeling> FeelingsReprositry { get; }

        //Task CompleteAsync();
        void SaveChanges();
        void SaveChangeAsyn();
    }
}
