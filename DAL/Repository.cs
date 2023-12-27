using pMan.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace pMan.DAL
{
    public abstract class Repository<T, Tcontext> : IRepository<T> where T : class where Tcontext : DbContext
    {
        protected readonly Tcontext DbContext;

        public Repository(Tcontext context)
        {
            DbContext = context;
        }


        public bool IsTransactionRunning()
        {
            return DbContext.Database.CurrentTransaction == null ? false : true;
        }
        private IDbContextTransaction BeginTran()
        {
            return DbContext.Database.BeginTransaction();
        }



        public IExecutionStrategy GetExecutionStrategy()
        {
            return DbContext.Database.CreateExecutionStrategy();
        }


        public IQueryable<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = DbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return result;
        }

        public async Task<ICollection<T>> GetAllByConditionAsync(Expression<Func<T, bool>> condition)
        {
            IQueryable<T> result = DbContext.Set<T>();
            if (condition != null)
            {
                result = result.Where(condition);
            }

            return await result.ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            IQueryable<T> result = DbContext.Set<T>();
            return result;
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            IQueryable<T> result = DbContext.Set<T>();
            return await result.ToListAsync();
        }

        public T GetSingle(Expression<Func<T, bool>> condition)
        {
            return DbContext.Set<T>().Where(condition).FirstOrDefault();
        }
        public async Task<T> GetSingleAysnc(Expression<Func<T, bool>> condition)
        {
            var retValue = await DbContext.Set<T>().Where(condition).SingleOrDefaultAsync();

            return retValue;
        }


        public bool Add(T entity)
        {
            DbContext.Set<T>().Add(entity);
            return true;
        }

        public bool Update(T entity)
        {
            DbContext.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public bool Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
            return true;
        }


        public void SaveChangesManaged()
        {
            DbContext.SaveChanges();
        }

    }
}
