using System;
using System.Collections.Generic;
using DomainModel;
using DomainPersistance;
using NUnit.Framework;

namespace PersistanceTests
{
    public class EmployeePersistanceTests : MsSqlEntityMappingSpec
    {
        private List<Employee> _testEmployees;
        private static List<Guid> _saveResults;

        protected override void Given()
        {
            base.Given();
            //load fake data to db
            _testEmployees = GenerateStubList();
            _saveResults = new List<Guid>();
            using (var tx = Session.BeginTransaction())
            {
                foreach (var employee in _testEmployees)
                {
                    var result = (Guid) Session.Save(employee);
                    _saveResults.Add(result);
                }
                tx.Commit();
            }
        }

        [Then]
        public void CanGetEmployeeById()
        {
            var empRepo = new EmployeeRepository(Session);
            //var testGuid = new Guid("11111111-1111-1111-1111-111111111111");

            var testId = GetRandomTestId();
            var testId2 = GetRandomTestId();
            var testId3 = GetRandomTestId();

            var emp = empRepo.GetEmployee(testId);

            Assert.IsNotNull(emp);
            Assert.AreEqual(testId, emp.Id);
        }


        [Then]
        public void CanSaveEmployee()
        {
            var empRepo = new EmployeeRepository(Session);
            int initialSkillsCount;

            //var theGuid = new Guid("11111111-1111-1111-1111-111111111111");
            var theGuid = GetRandomTestId();

            using (var tx = Session.BeginTransaction())
            {
                var emp = empRepo.GetEmployee(theGuid);
                initialSkillsCount = emp.Skills.Count;

                var newSkill = new Skill();
                emp.AddSkill(newSkill);

                theGuid = (Guid) empRepo.SaveEmployee(emp);
                tx.Commit();
                //Session.Flush();
            }

            var empResult = empRepo.GetEmployee(theGuid);
        }

        private static List<Employee> GenerateStubList()
        {
            var emp1 = new Employee
            {
                //Id = new Guid("11111111-1111-1111-1111-111111111111")
            };
            emp1.AddSkill(new Skill());

            var emp2 = new Employee
            {
                //Id = new Guid("22222222-2222-2222-2222-222222222222")
            };
            emp2.AddSkill(new Skill());

            var emp3 = new Employee
            {
                //Id = new Guid("33333333-3333-3333-3333-333333333333")
            };
            emp2.AddSkill(new Skill());

            var emp4 = new Employee
            {
                //Id = new Guid("44444444-4444-4444-4444-444444444444")
            };
            emp4.AddSkill(new Skill());

            return new List<Employee>
            {
                emp1,
                emp2,
                emp3,
                emp4
            };
        }

        private static Guid GetRandomTestId()
        {
            var testGuid = _saveResults[new Random().Next(_saveResults.Count)];
            return testGuid;
        }
    }
}