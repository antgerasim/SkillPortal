using System;
using DomainModel;
using DomainModel.Mapping;
using DomainPersistance;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Testing;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Persister.Entity;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace PersistanceTests
{
    [TestFixture]
    public class MsSqlEntityMappingSpec : MappingSpecificationBase
    {
        protected override IPersistenceConfigurer DefineDatabase()
        {
            return MsSqlConfiguration
                .MsSql2012
                .ConnectionString(
                    "Data Source=Programming\\sqlexpress;Initial Catalog=SkillPortal;Integrated Security=True")
                .ShowSql();
        }

        protected override void DefineMappings(MappingConfiguration m)
        {
            m.FluentMappings.AddFromAssemblyOf<EmployeeMap>();
        }

        protected override void CreateSchema(Configuration cfg)
        {
            new SchemaExport(cfg).Execute(true, true, false);
        }

        protected override void BeforeAllTests()
        {
            base.BeforeAllTests();
            //log4net.Config.XmlConfigurator.Configure();
        }

        //private static void CleanUpTable<T>(ISessionFactory sessionFactory)
        //{
        //    var metadata = sessionFactory.GetClassMetadata(typeof (T)) as AbstractEntityPersister;
        //    string table = metadata.TableName;

        //    using (ISession session = sessionFactory.OpenSession())
        //    {
        //        using (var tx = session.BeginTransaction())
        //        {
        //            string deleteAll = string.Format("DELETE FROM \"{0}\"", table);
        //            session.CreateSQLQuery(deleteAll).ExecuteUpdate();

        //            tx.Commit();
        //        }
        //    }
        //}


        [Then]
        public void ItShouldSaveAndReloadTheProductCorrectly()
        {
            var product = new Product
            {
                Name = "Apple",
                Category = "Ficken3",
                Discontinued = false
            };
            Session.Save(product);
            Session.Flush();
            Session.Evict(product);
            Session.Clear();

            var fromDb = Session.Get<Product>(product.Id);
            Assert.That(fromDb, Is.Not.Null);
            Assert.That(fromDb.Name, Is.EqualTo(product.Name));
            Assert.That(fromDb.Category, Is.EqualTo(product.Category));
            Assert.That(fromDb.Discontinued, Is.EqualTo(product.Discontinued));

           // CleanUpTable<Product>(Session.SessionFactory);
        }

        [Then]
        public void ItShouldCorrectlyMapAProduct()
        {
            new PersistenceSpecification<Product>(Session)
                .CheckProperty(x => x.Name, "Apple")
                .CheckProperty(x => x.Category, "Fotzchen")
                .CheckProperty(x => x.Discontinued, true)
                .VerifyTheMappings();
        }
    }
}