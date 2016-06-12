using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DomainModel.Helpers;
using DomainPersistance;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;

namespace SkillPortalSite.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //unit of work per request
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

            //default binding for everything except unit of work
            _kernel.Bind(
                x =>
                    x.FromAssembliesMatching("*")
                        .SelectAllClasses()
                        .Excluding<UnitOfWork>()
                        .BindDefaultInterface());
        }
    }
}