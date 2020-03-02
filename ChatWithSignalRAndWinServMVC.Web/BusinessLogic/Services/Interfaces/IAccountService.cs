using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.AccountViews;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces
{
    public interface IAccountService : IDisposable
    {
        Task<IdentityResult> Register(RegisterAccountView model);

        Task<SignInStatus> Login(LoginAccountView model);

        Task<GetCurrentUserInfoAccountView> GetCurrentUserInfo(string userId);

        Task Logout();

        EmptyResult Authorize(IPrincipal user);
    }
}
