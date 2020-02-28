using ChatWithSignalRAndWinServMVC.Web.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.UnitOfWork
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IChatRepository Chats { get; }
        IMessageRepository Messages { get; }
        IUserRepository Users { get; }
    }
}
