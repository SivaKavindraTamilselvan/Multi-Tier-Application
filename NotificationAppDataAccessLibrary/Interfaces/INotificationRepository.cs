using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppModelLibrary;
public interface INotificationRepository 
    : IRepository<int, Notification>
{
    List<Notification> GetNotificationByUserId(int userId);
    public List<Notification> GetNotificationsByUserIdAndService(int userId,string service);
    public List<Notification> GetNotificationsByService(string service);
}