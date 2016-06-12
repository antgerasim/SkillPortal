using System;
using DomainModel;
using NHibernate;

namespace DomainPersistance
{
    public class EmployeeRepository :Repository<Employee>
    {
        
        public EmployeeRepository(ISession session) : base(session)
        {

        }

        public Employee GetEmployee(Guid id)
        {
            return base.Get(id);
        }

        public object SaveEmployee(Employee emp)
        {
            return base.Save(emp);
        }
    }
}

//We dont want our repository to be responsible for constructing our own session.We want the repo
//to participate in an higher order unit of work and get the session object injected. Session Lifecycle
//should not be controlled by repository, but is controlled by the code who calls the repo.