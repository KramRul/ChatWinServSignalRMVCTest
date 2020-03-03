using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews.Pages
{
    public class ChatIndexPageView
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Chat name")]
        public string ChatName { get; set; }

        public ChatItemView CurrentChat { get; set; }

        public IEnumerable<ChatItemView> Chats { get; set; }

        public ChatIndexPageView()
        {
            Chats = new List<ChatItemView>();
        }
    }
}