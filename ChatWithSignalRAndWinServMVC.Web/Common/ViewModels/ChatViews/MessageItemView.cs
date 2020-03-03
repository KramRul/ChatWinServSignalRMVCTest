using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.Common.ViewModels.ChatViews
{
    public class MessageItemView
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public UserItemView Sender { get; set; }
        public string SenderId { get; set; }
        public DateTimeOffset SendDate { get; set; }
        public Guid ChatId { get; set; }
    }
}