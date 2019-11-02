using BlogApp.Web.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlogApp.Web.Services
{
    public class NotificationService : IHostedService
    {
        private static ConnectionMultiplexer _redis;
        private static ISubscriber _sub;
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;

          
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _redis = ConnectionMultiplexer.Connect("localhost");
            if (_redis.IsConnected)
            {
                _sub = _redis.GetSubscriber();
                if (_sub != null)
                {
                    _sub.Subscribe("notification", async (channel, message) => {

                        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.ToString());
                    });
                }
            }

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
