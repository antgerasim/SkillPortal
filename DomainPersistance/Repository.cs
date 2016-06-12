using System;
using System.Linq;
using DomainModel;
using DomainModel.Helpers;
using NHibernate;
using NHibernate.Linq;
using Proteus.Domain.Foundation;

namespace DomainPersistance
{
    public class Repository<T> : IRepository<T> where T :IdentityPersistenceBase<T, Guid, string>
    {
        private UnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork) unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public T GetById(int id)
        {
            return Session.Get<T>(id);
        }

        public void Create(T entity)
        {
            Session.Save(entity);
        }

        public void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(int id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}