using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

public interface INotificationService
{
    public void CreateNotification(string message,User user,string service);
    public Notification? GetNotificationsById(int id);
    public void PrintAllNotification();
    public List<Notification> GetNotificationsByUserId(int id);
    public void SendNotificationToUsers(string message,User user,string service);
}