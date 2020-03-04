using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<ChatItemView>> GetAvailableChats(string userId);

        Task<IEnumerable<ChatItemView>> AddChat(string userId, string chatName);

        Task AddMessage(Guid chatId, string message, string userId);
    }
}
