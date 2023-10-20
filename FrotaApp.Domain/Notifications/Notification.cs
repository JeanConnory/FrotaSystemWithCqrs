namespace FrotaApp.Domain.Notifications
{
    public class Notification
    {
        public string PropertyName { get; set; }

        public string Message { get; set; }

        public Notification(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
    }
}
