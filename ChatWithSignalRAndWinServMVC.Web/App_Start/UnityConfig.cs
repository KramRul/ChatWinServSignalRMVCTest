using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services;
using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using ChatWithSignalRAndWinServMVC.Web.DataAccess;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Web;
using Unity;
using Unity.Injection;

namespace ChatWithSignalRAndWinServMVC.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            container.RegisterInstance<ChatDBContext>(new ChatDBContext());
            container.RegisterType<DbContext, ChatDBContext>();
            container.RegisterType<IBaseUnitOfWork, UnitOfWork>();
            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IChatService, ChatService>();
            container.RegisterType<ApplicationSignInManager>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(c => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<IUserStore<User>, UserStore<User>>(new InjectionConstructor(typeof(ChatDBContext)));
        }
    }
}