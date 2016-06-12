using System;
using DomainModel;
using DomainModel.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace PersistanceTests
{
    [TestFixture]
    public class DatabaseMaintenance//ex public class PersistenceTests
    {
        protected Configuration Cfg;
        private static ISessionFactory _sessionFactory;
        protected ISession Session;


        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            BeforeAllTests();
        }

        [SetUp]
        public void Setup()//Given();//When();
        {
            
            //_firstName = "Anton";
            //_middleName = "Julevich";
            //_lastName = "Gerasimov";
            Session = OpenSession();

            
            // _result = new Name(_firstName, _middleName, _lastName);
        }

        [Test]
        public void ItShouldCorrectlyMapAProduct()
        {
            new PersistenceSpecification<Product>(Session)
                .CheckProperty(x => x.Name, "Apple")
                .CheckProperty(x => x.Category, "Ficken")
                .CheckProperty(x => x.Discontinued, true)
                .VerifyTheMappings();
        }


        private IPersistenceConfigurer DefineDatabase()
        {
            return
                MsSqlConfiguration
                .MsSql2012
                .ConnectionString(
                    "Data Source=Programming\\sqlexpress;Initial Catalog=SkillPortal;Integrated Security=True")
                    .ShowSql();
        }

        private void DefineMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<EmployeeMap>();
        }

        private void ExecuteSchemaToDbDropAndCreate(Configuration cfg)
        {
            var schema = new SchemaExport(cfg);
            schema.Execute(false, true,false);
        }

        private void BeforeAllTests()
        {
            Cfg = new Configuration();
            Cfg = Fluently.Configure()
                .Database(DefineDatabase)
                .Mappings(DefineMappings)
                .BuildConfiguration();

            ExecuteSchemaToDbDropAndCreate(Cfg);

            _sessionFactory = Cfg.BuildSessionFactory();

            Session = _sessionFactory.OpenSession();
        }

        protected ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
}
/*Works! Creates a as many tables as entities & components mapped. The database catalogue must be created first though*/