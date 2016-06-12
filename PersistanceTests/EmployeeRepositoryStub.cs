using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel;
using DomainPersistance;
using NHibernate;

namespace PersistanceTests
{
    internal class EmployeeRepositoryStub : Repository<Employee>
    {
        //private readonly IQueryable<Employee> _stubList;
        private readonly List<Employee> _stubList;


        internal EmployeeRepositoryStub(ISession session) : base(session)
        {
            _stubList = GenerateStubList();
        }

        internal IQueryable<Employee> Query()
        {
            return _stubList.AsQueryable();
        }

        internal Employee GetEmployee(Guid id)
        {
            //return Get(id);
            var result = GenerateStubList().FirstOrDefault(x => x.Id == id);

            //_stubList.
            return result;
        }

        //internal int SaveEmployee(Employee emp)
        //{
        //    /Sess
        //}

        private static List<Employee> GenerateStubList()
        {
            var emp1 = new Employee()
            {
                Id = new Guid("11111111-1111-1111-1111-111111111111"),
            };
            emp1.AddSkill(new Skill());

            var emp2 = new Employee()
            {
                Id = new Guid("22222222-2222-2222-2222-222222222222"),
            };
            emp2.AddSkill(new Skill());

            var emp3 = new Employee()
            {
                Id = new Guid("33333333-3333-3333-3333-333333333333"),
            };
            emp2.AddSkill(new Skill());

            var emp4 = new Employee()
            {
                Id = new Guid("44444444-4444-4444-4444-444444444444")
            };
            emp4.AddSkill(new Skill());

            return new List<Employee>()
            {
                emp1,emp2,emp3,emp4
            };
        }
    }
}