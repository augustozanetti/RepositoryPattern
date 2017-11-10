using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using RepositoryPattern.domain.Repositories;
using RepositoryPattern.Infra.Repositories;
using RepositoryPattern.Infra.Contexts;
using RepositoryPattern.Infra.UoW;

namespace RepositoryPattern.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            //Unity.mvc3
            var container = new UnityContainer();
                
            container.RegisterType<AppDataContext, AppDataContext>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            return container;
        }
    }
}