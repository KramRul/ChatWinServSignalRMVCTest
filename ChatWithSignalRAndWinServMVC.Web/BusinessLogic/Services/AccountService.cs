using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using ChatWithSignalRAndWinServMVC.Web.Common.Exceptions;
using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.AccountViews;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Newtonsoft.Json;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services
{
    public class AccountService : BaseService, IAccountService
    {
        private readonly UserManager<User> _userManager;

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().Authentication;
            }
        }

        public AccountService(
            UserManager<User> userManager,
            IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _userManager = userManager;
        }

        public async Task<LoginAccountResponseView> Login(LoginAccountView model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                throw new CustomServiceException("Player does not exist.");
            }

            var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isValidPassword)
            {
                throw new CustomServiceException("Invalid username or password.");
            }

            ClaimsIdentity claim = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignOut();
            AuthenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = true
            }, claim);
            var result = new LoginAccountResponseView()
            {
                UserName = user.UserName
            };
            return result;
        }

        public async Task<RegisterAccountResponseView> Register(RegisterAccountView model)
        {
            var existedPlayear = await _userManager.FindByNameAsync(model.UserName);
            if (existedPlayear != null)
            {
                throw new CustomServiceException("Player allready exist.");
            }

            var user = new User
            {
                UserName = model.UserName
            };

            var createdUser = await _userManager.CreateAsync(user, model.Password);

            if (!createdUser.Succeeded)
            {
                throw new CustomServiceException("The user was not registered");
            }

            var result = new RegisterAccountResponseView()
            {
                UserName = user.UserName
            };

            return result;
        }

        public async Task Logout()
        {
            AuthenticationManager.SignOut();
        }

        public async Task<GetCurrentUserInfoAccountView> GetCurrentUserInfo(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new CustomServiceException("Player does not exist.");
            }

            var result = new GetCurrentUserInfoAccountView()
            {
                UserName = user.UserName
            };

            return result;
        }
    }
}
