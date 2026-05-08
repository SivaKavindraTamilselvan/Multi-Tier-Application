using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppModelLibrary;
public interface INotificationRepository 
    : IRepository<int, Notification>
{
    List<Notification> GetNotificationByUserId(int userId);
}