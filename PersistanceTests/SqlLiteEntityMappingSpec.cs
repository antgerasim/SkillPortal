using System;
using DomainModel;
using DomainModel.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace PersistanceTests
{
    [TestFixture]
    public class SqlLiteEntityMappingSpec
    {
        private ISessionFactory _sessionFactory;
        protected ISession Session;

       [Test]
        public void Test()
        {
            try
            {
                var cfg = Fluently.Configure()
                    .Database(SQLiteConfiguration.Standard
                        .InMemory()
                        .ShowSql()
                        .UsingFile("SkillPortal.db"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<EmployeeMap>())
                    .BuildConfiguration();

                var schema = new SchemaExport(cfg);
                schema.Create(false, true);

                try
                {
                    _sessionFactory = cfg.BuildSessionFactory();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                Session = _sessionFactory.OpenSession();

                var skill = new Skill();
                var emp = new Employee();

                emp.AddSkill(skill);

                var empId = Session.Save(emp);

                Session.Flush();

                Session.Evict(emp);

                var empWithSkil = Session.Get<Employee>(empId);
                Assert.IsNotNull(empWithSkil);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}


//inMemory assembly
//http://codebetter.com/johnvpetersen/2009/11/23/new-version-of-ndbunit-released-support-for-sqlite-in-memory-db/
//https://github.com/NDbUnit/NDbUnit/blob/master/test/NDbUnit.Test/SqlLite-InMemory/SQLliteInMemoryIntegrationTest.cs

//good tutorial
//http://www.nhforge.org/wikis/howtonh/your-first-nhibernate-based-application.aspx