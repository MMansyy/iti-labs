using System.Linq.Expressions;

namespace Lab_2.Repos
{
    public interface IEntities<T> where T : class
    {
        IEnumerable<T> GetAll(int page = 1, int pageSize = 10, Expression<Func<T, bool>>? filter = null, string? includedProp = null);
        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}