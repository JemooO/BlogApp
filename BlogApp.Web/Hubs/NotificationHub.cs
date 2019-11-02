using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace BlogApp.Web.Hubs
{
    public class NotificationHub : Hub
    {
        
        public async Task BroadcastMessage(string message)
        {
            
             
        }

        public override Task OnConnectedAsync()
        {
            HubManager.SetNotification(this);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

    }
}
