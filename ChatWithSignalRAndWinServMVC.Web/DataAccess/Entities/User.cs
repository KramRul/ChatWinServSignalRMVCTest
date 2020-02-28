using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.DataAccess.Entities
{
    public class User : IdentityUser
    {
        public string ConnectionId { get; set; }
    }
}