using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Core.Business.Object;
using Core.DataAccess;
using Core.DataAccess.Data;
using Core.Service.Users;
using Core.Service.Function;
using Core.Business.EF;

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
           
            container.RegisterType<IRepository<CoreUser>, EfRepository<CoreUser>>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRepository<CoreFunction>, EfRepository<CoreFunction>>();
            container.RegisterType<IFunctionService, FunctionService>();            
        }
    }
}