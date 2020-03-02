using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatWithSignalRAndWinServMVC.Web.Common.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string ConnectionId { get; set; }
}
}