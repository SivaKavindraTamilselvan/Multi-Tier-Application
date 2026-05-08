using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

public interface INotification
{
    public void CreateNotification(Notification item);
    public Notification? GetNotificationsById(int id);
    public void PrintAllNotification();
    public List<Notification> GetNotificationsByUserId(int id);
}