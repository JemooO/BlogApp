namespace BlogApp.Core.Notification
{
    public interface INotification
    {
        /// <summary>
        /// Notification submit function to notify users.
        /// </summary>
        /// <param name="title">the title of the notification</param>
        /// <param name="content">the content of the notification</param>
        /// <param name="targetUrl">when I click on the notification, where it will redirect me</param>
        /// <param name="targetPerson">targetted person, empty string means all</param>
        public void SubmitNotification(string content, string targetUrl, string targetPerson = "");
    }
}
