using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories
{
    public class ChatRepository : BaseRepository<Chat>, IChatRepository
    {
        public ChatRepository(ChatDBContext context) : base(context)
        {
        }
    }
}