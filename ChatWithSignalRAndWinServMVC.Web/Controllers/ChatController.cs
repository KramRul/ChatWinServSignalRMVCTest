using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChatWithSignalRAndWinServMVC.Web.Controllers
{
    [Authorize]
    public class ChatController : BaseController
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}
