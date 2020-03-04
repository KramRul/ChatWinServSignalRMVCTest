using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews.Pages
{
    public class ChatMessagesPageView
    {
        public ChatItemView CurrentChat { get; set; }

        public IEnumerable<ChatItemView> Chats { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "New Message")]
        public string NewMessage { get; set; }

        public ChatMessagesPageView()
        {
            Chats = new List<ChatItemView>();
        }
    }
}