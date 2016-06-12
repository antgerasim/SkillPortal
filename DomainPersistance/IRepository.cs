using System;
using System.Linq;

namespace DomainPersistance
{
    /// <summary>
    /// Schenkers Version of Repositories
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}