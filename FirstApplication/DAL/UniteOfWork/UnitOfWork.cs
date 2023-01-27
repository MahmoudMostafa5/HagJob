using FirstApplication.DAL.GenaricRepo;
using FirstApplication.DAL.NonGenaric;
using FirstApplication.DB;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DAL.UniteOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JobsContext _context;
        private readonly ILogger _logger;


        public IGenericRepository<jobs> JobReprositry { get; private set; }
        public IGenericRepository<UserType> usertypeReprositry { get; private set; }

        public IGenericRepository<UserInformation> UserInformationReprositry { get; private set; }

        public IGenericRepository<Adresss> AdreesReprositry { get; private set; }

        public IGenericRepository<Department> DepartmentReprositry { get; private set; }

        public IJobReprositry JobrepoMethods { get; }
        public IQuestionReprositry QuestionReprositryMethods { get; }


        public IGenericRepository<QuestionJob> QUestionsJobReprositry { get; private set; }

        public IGenericRepository<Post> PostsReprositry { get; private set; }

        public IGenericRepository<Feeling> FeelingsReprositry { get; private set; }

        public UnitOfWork(
            JobsContext context,
            ILoggerFactory loggerFactory,
            IJobReprositry joprepo
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            JobReprositry = new GenericRepository<jobs>(_context);
            usertypeReprositry = new GenericRepository<UserType>(_context);
            UserInformationReprositry = new GenericRepository<UserInformation>(_context);
            AdreesReprositry = new GenericRepository<Adresss>(_context);
            DepartmentReprositry = new GenericRepository<Department>(_context);
            QUestionsJobReprositry = new GenericRepository<QuestionJob>(_context);
            JobrepoMethods = new JobReprositry(_context);
            QuestionReprositryMethods = new QuestionReprositry(_context);
            PostsReprositry = new GenericRepository<Post>(_context);
            FeelingsReprositry = new GenericRepository<Feeling>(_context);
        }

        //public Task CompleteAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        void IUnitOfWork.SaveChanges()
        {
            _context.SaveChanges();
        }

        public void  SaveChangeAsyn()
        {
             _context.SaveChangesAsync();
        }
    }
}
