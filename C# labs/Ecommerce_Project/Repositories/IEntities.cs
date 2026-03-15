using System.Linq.Expressions;

namespace Ecommerce_Project.Repositories
{
    public interface IEntities<T>
    {
        IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = "");

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
