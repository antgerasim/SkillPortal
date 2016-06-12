using System.Runtime.CompilerServices;
using NHibernate.Hql.Ast;
using NUnit.Framework;

namespace PersistanceTests
{

    public abstract class SpecificationBase
    {
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            BeforeAllTests();
        }

        [SetUp]
        public void Setup()
        {
            Given();
            When();
            
        }

        [TearDown]
        public void Teardown()
        {
            CleanUp();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AfterAllTests();
        }
        protected virtual void BeforeAllTests()
        {
          
        }

        protected virtual void AfterAllTests()
        {
           
        }
        protected virtual void Given()
        {
           
        }
        protected virtual void When()
        {
           
        }
   
        protected virtual void CleanUp()
        {
            
        }

    }
}