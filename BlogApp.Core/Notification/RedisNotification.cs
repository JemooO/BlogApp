using BlogApp.Core.Contract;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace BlogApp.Core.Notification
{
    public class RedisNotification : INotification, IDisposable
    {
        private readonly ConnectionMultiplexer _redis;
        private readonly ISubscriber _sub;
        public RedisNotification()
        {
            _redis = ConnectionMultiplexer.Connect(ConfigurationManager.AppSettings["RedisHost"] ?? "localhost");
            if (_redis.IsConnected)
                _sub = _redis.GetSubscriber();
        }

        public void SubmitNotification(string content, string targetUrl, string targetPerson = "")
        {
            if (_sub != null)
            {
                var value = JsonConvert.SerializeObject(new NotificationContract()
                {
                    Content = content,
                    TargetUrl = targetUrl,
                    TargetPerson = targetPerson
                });
                _sub.Publish("notification", value);
            }
            
        }

        public void Dispose()
        {
            _redis.Dispose();
        }
    }
}
