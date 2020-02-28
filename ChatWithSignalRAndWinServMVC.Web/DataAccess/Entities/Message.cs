using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities
{
    public class Message : BaseEntity
    {
        public string Text { get; set; }
        public string SenderId { get; set; }
        [ForeignKey("SenderId")]
        public User Sender { get; set; }
        public DateTimeOffset SendDate { get; set; }
        [ForeignKey("ChatId")]
        public Chat Chat { get; set; }
    }
}