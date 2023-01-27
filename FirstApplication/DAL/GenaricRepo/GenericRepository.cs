using FirstApplication.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApplication.DAL.GenaricRepo
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected JobsContext _context;
        protected DbSet<T> table;
        //private jobs context;
        protected readonly ILogger _logger;
        // Start At Empty argument in Constractor
        //public GenericRepository() {

        //}
        // End At Empty argument in Constractor
        public GenericRepository(
            JobsContext context
            //ILogger logger
        )
        {
            _context = context;
            //_logger = logger;
            this.table = context.Set<T>();
        }


        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        //public IEnumerable<T> GetAllWithInclude()
        //{
        //    return table
        //}
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
