using Ecommerce_Project.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce_Project.Repositories
{
    public class EntityRepo<T> : IEntities<T> where T : class
    {

        DBContext context;
        DbSet<T> dbSet;

        public EntityRepo(DBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            if (entity != null)
            {
                dbSet.Add(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet.AsNoTracking();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query;

        }

        public T GetById(int id)
        {
            return dbSet.Find(id);
        }


        public void Update(T entity)
        {
            if (entity != null)
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
