using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace PersistanceTests
{
    public abstract class MappingSpecificationBase : SpecificationBase
    {
        private ISessionFactory _sessionFactory;
        protected Configuration Cfg;
        protected ISession Session;

        protected override void BeforeAllTests()
        {
            Cfg = Fluently.Configure()
                .Database(DefineDatabase)
                .Mappings(DefineMappings)
                .BuildConfiguration();

            CreateSchema(Cfg);

            _sessionFactory = Cfg.BuildSessionFactory();
        }

        protected abstract void DefineMappings(MappingConfiguration obj);

        protected abstract IPersistenceConfigurer DefineDatabase();

        protected virtual void CreateSchema(Configuration cfg)
        {
        }

        protected override void Given()
        {
            base.Given();
            Session = OpenSession();
        }

        protected ISession OpenSession()
        {
            return _sessionFactory.OpenSession();
        }
     
    }
}