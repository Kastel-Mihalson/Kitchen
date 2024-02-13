using System.Linq.Expressions;

namespace Kitchen.UseCases.Interfaces
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Update(IReadOnlyList<T> entity);
        void Delete(T entity);
        void Delete(IReadOnlyList<T> entities);
    }
}
