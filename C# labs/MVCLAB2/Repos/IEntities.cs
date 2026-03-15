using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MVCLAB2.Repos
{
    public interface IEntities<T>
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null , string? includeProperties = "");

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
