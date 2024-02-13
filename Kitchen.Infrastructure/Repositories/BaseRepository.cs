using Kitchen.UseCases.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Kitchen.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected KitchenDbContext DbContext { get; set; }

        public BaseRepository(KitchenDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return DbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            return DbContext.Set<T>().Where(condition).AsNoTracking();
        }

        public void Create(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Set<T>().Update(entity);
        }

        public void Update(IReadOnlyList<T> entities)
        {
            foreach (T entity in entities)
            {
                Update(entity);
            }
        }

        public void Delete(T entity)
        {
            DbContext.Set<T>().Remove(entity);
        }

        public void Delete(IReadOnlyList<T> entities)
        {
            foreach (T entity in entities)
            {
                Delete(entity);
            }
        }
    }
}
