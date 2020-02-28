using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities
{
    public class Chat : BaseEntity
    {
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}