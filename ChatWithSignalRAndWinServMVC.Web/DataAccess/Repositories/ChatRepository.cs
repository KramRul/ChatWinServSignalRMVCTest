using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(ChatDBContext context) : base(context)
        {
        }

        public async Task<List<ChatItemView>> AddChat(string userId, string chatName)
        {
            await Create(new Chat()
            {
                Id = Guid.NewGuid(),
                Messages = new List<Message>(),
                Name = chatName,
                UserId = userId
            });
            return await dataBase.Chats.Where(chat => chat.UserId == userId).Select(chat => new ChatItemView()
            {
                Id = chat.Id,
                ChatName = chat.Name,
                FirstMessage = chat.Messages.Select(message => new MessageItemView()
                {
                    Id = message.Id,
                    ChatId = message.ChatId,
                    SendDate = message.SendDate,
                    SenderId = message.SenderId,
                    Text = message.Text,
                    Sender = new UserItemView()
                    {
                        Id = message.Sender.Id,
                        UserName = message.Sender.UserName
                    }
                }).FirstOrDefault(),
                Messages = chat.Messages.Select(message => new MessageItemView()
                {
                    Id = message.Id,
                    ChatId = message.ChatId,
                    SendDate = message.SendDate,
                    SenderId = message.SenderId,
                    Text = message.Text,
                    Sender = new UserItemView()
                    {
                        Id = message.Sender.Id,
                        UserName = message.Sender.UserName
                    }
                })
            }).ToListAsync();
        }

        public async Task<List<ChatItemView>> GetAvailableChats(string userId)
        {
            var result = await dataBase.Chats.Where(chat => chat.UserId == userId).Select(chat => new ChatItemView()
            {
                Id = chat.Id,
                ChatName = chat.Name,
                FirstMessage = chat.Messages.Select(message => new MessageItemView()
                {
                    Id = message.Id,
                    ChatId = message.ChatId,
                    SendDate = message.SendDate,
                    SenderId = message.SenderId,
                    Text = message.Text,
                    Sender = new UserItemView()
                    {
                        Id = message.Sender.Id,
                        UserName = message.Sender.UserName
                    }
                }).FirstOrDefault(),
                Messages = chat.Messages.Select(message => new MessageItemView()
                {
                    Id = message.Id,
                    ChatId = message.ChatId,
                    SendDate = message.SendDate,
                    SenderId = message.SenderId,
                    Text = message.Text,
                    Sender = new UserItemView()
                    {
                        Id = message.Sender.Id,
                        UserName = message.Sender.UserName
                    }
                })
            }).ToListAsync();
            return result;
        }
    }
}