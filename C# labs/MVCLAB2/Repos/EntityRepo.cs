using Microsoft.EntityFrameworkCore;
using MVCLAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVCLAB2.Repos
{
    public class EntityRepo<T> : IEntities<T> where T : class
    {

        ITIContextcs context;
        DbSet<T> dbSet;

        public EntityRepo(ITIContextcs context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var property in includeProperties.Split("," , StringSplitOptions.RemoveEmptyEntries))
                {
                    var value = property.Trim();
                    query = query.Include(value);
                }
            }
            return query.ToList();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
