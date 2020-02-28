using ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces
{
    public interface IMessageRepository : IBaseRepository<Message>
    {
    }
}