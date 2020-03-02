using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ChatWithSignalRAndWinServMVC.Web.Common.DTOs;
using ChatWithSignalRAndWinServMVC.Web.Models;
using Microsoft.AspNet.SignalR;

namespace ChatWithSignalRAndWinServMVC.Web.Hubs
{
    public class ChatHub : Hub
    {
        static List<UserDto> Users = new List<UserDto>();
        
        public void Send(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
        
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new UserDto { ConnectionId = id, UserName = userName });
                Clients.Caller.onConnected(id, userName, Users);
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }
        
        public override Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.UserName);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}