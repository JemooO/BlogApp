using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Web.Hubs
{
    public class HubManager
    {
        private static NotificationHub _notification;
        private static object _lock = new object();

        public static void SetNotification(NotificationHub hub)
        {
            if (_notification == null)
                _notification = hub;
        }

        public static NotificationHub Notification
        {
            get
            {
                if (_notification == null)
                    lock (_lock)
                    {
                        if (_notification == null)
                            _notification = new NotificationHub();
                    }
                return _notification;
            }
        }

    }
}
