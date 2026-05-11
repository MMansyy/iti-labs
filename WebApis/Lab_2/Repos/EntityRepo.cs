using Lab_2.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Lab_2.Repos
{
    public class EntityRepo<T> : IEntities<T> where T : class
    {
        private readonly ITIContext _context;
        private readonly DbSet<T> _dbSet;

        public EntityRepo(ITIContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll(int page = 1, int pageSize = 10, Expression<Func<T, bool>>? filter = null, string? includedProp = null)
        {
            page = page <= 0 ? 1 : page;
            pageSize = pageSize <= 10 ? 10 : pageSize;

            var query = _dbSet.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (includedProp != null)
            {
                foreach (var included in includedProp.Split(",", StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(included);
                }
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return query.ToList();
        }

        public T? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}