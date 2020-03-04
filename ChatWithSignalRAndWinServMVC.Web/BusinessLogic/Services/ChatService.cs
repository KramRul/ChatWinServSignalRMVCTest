using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services
{
    public class ChatService : BaseService, IChatService
    {
        public ChatService(IBaseUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task<IEnumerable<ChatItemView>> AddChat(string userId, string chatName)
        {
            var result = await _database.Chats.AddChat(userId, chatName);
            return result;
        }

        public async Task AddMessage(Guid chatId, string message, string userId)
        {
            await _database.Messages.Create(new DataAccess.Entities.Message()
            {
                Id = Guid.NewGuid(),
                ChatId = chatId,
                SendDate = DateTimeOffset.UtcNow,
                SenderId = userId,
                Text = message
            });
        }

        public async Task<IEnumerable<ChatItemView>> GetAvailableChats(string userId)
        {
            var result = await _database.Chats.GetAvailableChats(userId);
            return result;
        }
    }
}
