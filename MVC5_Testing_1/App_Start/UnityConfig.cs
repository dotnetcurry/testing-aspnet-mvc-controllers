using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

using MVC5_Testing_1.ModelAccess;

namespace MVC5_Testing_1
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IDepartmentAccess, DepartmentAccess>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}