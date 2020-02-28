using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.AccountViews;
using System.Threading.Tasks;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterAccountResponseView> Register(RegisterAccountView model);

        Task<LoginAccountResponseView> Login(LoginAccountView model);

        Task<GetCurrentUserInfoAccountView> GetCurrentUserInfo(string userId);
    }
}
