using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using ChatWithSignalRAndWinServMVC.Web.Common.Exceptions;
using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.AccountViews;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountService(
            ApplicationUserManager userManager, 
            ApplicationSignInManager signInManager, 
            IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public EmptyResult Authorize(IPrincipal user)
        {
            var claims = new ClaimsPrincipal(user).Claims.ToArray();
            var identity = new ClaimsIdentity(claims, "Bearer");
            AuthenticationManager.SignIn(identity);
            return new EmptyResult();
        }

        public async Task<SignInStatus> Login(LoginAccountView model)
        {
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                throw new CustomServiceException("User does not exist.");
            }

            var isValidPassword = await UserManager.CheckPasswordAsync(user, model.Password);
            if (!isValidPassword)
            {
                throw new CustomServiceException("Invalid username or password.");
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);

            return result;
        }

        public async Task<IdentityResult> Register(RegisterAccountView model)
        {
            var existedPlayear = await UserManager.FindByNameAsync(model.UserName);
            if (existedPlayear != null)
            {
                throw new CustomServiceException("User allready exist.");
            }

            var user = new User
            {
                UserName = model.UserName
            };

            var createdUser = await UserManager.CreateAsync(user, model.Password);

            if (!createdUser.Succeeded)
            {
                throw new CustomServiceException("The user was not registered");
            }

            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

            return createdUser;
        }

        public async Task Logout()
        {
            AuthenticationManager.SignOut();
        }

        public async Task<GetCurrentUserInfoAccountView> GetCurrentUserInfo(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new CustomServiceException("User does not exist.");
            }

            var result = new GetCurrentUserInfoAccountView()
            {
                UserName = user.UserName
            };

            return result;
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            Dispose(disposing);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
