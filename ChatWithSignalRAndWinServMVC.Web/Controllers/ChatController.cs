using ChatWithSignalRAndWinServMVC.Web.BusinessLogic.Services.Interfaces;
using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews;
using ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var chats = await _chatService.GetAvailableChats(UserId);
            return View(new ChatIndexPageView()
            {
                Chats = chats
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddChat(CreateChatPartialPageView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var chats = await _chatService.AddChat(UserId, model.ChatName);
            return View("Index", new ChatIndexPageView()
            {
                Chats = chats
            });
        }

        [HttpGet]
        public async Task<ActionResult> ChatMessages(string chatId)
        {
            var chats = await _chatService.GetAvailableChats(UserId);
            return View(new ChatMessagesPageView()
            {
                Chats = chats,
                CurrentChat = chats.Where(chat => chat.Id == Guid.Parse(chatId)).FirstOrDefault()
            });
        }
        
        [HttpPost]
        public async Task<ActionResult> AddMessage(ChatMessagesPageView model, Guid currentChatId)
        {
            if (!ModelState.IsValid)
            {
                return View("ChatMessages", model);
            }
            await _chatService.AddMessage(currentChatId, model.NewMessage, UserId);
            return RedirectToAction("ChatMessages", new { ChatId = currentChatId });
        }
    }
}
