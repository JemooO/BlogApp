using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Core.Notification
{
    public class NotificationManager
    {
        private static INotification _notification;
        private static object _lock = new object();

        public static INotification Notification
        {
            get
            {
                if (_notification == null)
                    lock(_lock)
                        if (_notification == null)
                        {
                            _notification = new Notification.RedisNotification();
                        }
                return _notification;
            }
        }
    }
}
