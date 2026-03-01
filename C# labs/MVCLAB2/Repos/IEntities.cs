using System.Collections.Generic;

namespace MVCLAB2.Repos
{
    public interface IEntities<T>
    {
        List<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Delete(int id);

    }
}
