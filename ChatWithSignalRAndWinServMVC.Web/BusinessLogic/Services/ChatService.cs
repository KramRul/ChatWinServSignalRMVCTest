using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
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
    }
}
