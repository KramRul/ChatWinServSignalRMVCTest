using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces
{
    public interface IChatRepository : IBaseRepository<Chat>
    {
        Task<List<ChatItemView>> GetAvailableChats(string userId);

        Task<List<ChatItemView>> AddChat(string userId, string chatName);
    }
}
