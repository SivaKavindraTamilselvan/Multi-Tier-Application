namespace NotificationAppModelLibrary;

public class Notification
{
    public int notificationId {get;set;}
    public int userId {get;set;}
    public string message {get;set;} = "";
    public string service {get;set;} = "";
    public DateTime? datetime {get;set;}
}