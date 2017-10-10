using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Core.Service.Users;
using Core.Business.Object;
using Core.DataAccess;
using Core.DataAccess.Data;

namespace Core.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //container.RegisterType<IRepository<User>, EfRepository<User>>();
            //container.RegisterType<IUserService, UserService>();
            
            container.RegisterInstance<IUserService>(new UserService());
            container.RegisterInstance<IRepository<User>>(new EfRepository<User>());
        }
    }
}