using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews
{
    public class ChatItemView
    {
        public Guid Id { get; set; }
        public string ChatName { get; set; }
        public MessageItemView FirstMessage { get; set; }
        public IEnumerable<MessageItemView> Messages { get; set; }

        public ChatItemView()
        {
            Messages = new List<MessageItemView>();
        }
    }
}