using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services;
using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using ChatWithSignalRAndWinServMVC.Web.DataAccess;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Lifetime;

namespace ChatWithSignalRAndWinServMVC.Web.Common.Helpers
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        protected IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return container.Resolve(serviceType);
            }
            catch (ResolutionFailedException ex)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public IDependencyScope BeginScope()
        {
            var child = container.CreateChildContainer();
            return new UnityDependencyResolver(child);
        }

        public void Dispose()
        {
            container.Dispose();
        }

        public static UnityContainer RegisterTypes()
        {
            UnityContainer container = new UnityContainer();
            container.RegisterInstance<ChatDBContext>(new ChatDBContext());
            container.RegisterType<IBaseUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<IAccountService, AccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<IChatService, ChatService>(new HierarchicalLifetimeManager());
            return container;
        }
    }
}