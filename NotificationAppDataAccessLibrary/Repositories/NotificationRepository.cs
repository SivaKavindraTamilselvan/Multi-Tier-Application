using NotificationAppModelLibrary;

namespace NotificationAppDataAccessLibrary.Repositories;

public class NotificationRepository : AbstractRepository<int,Notification>
{
    static int notificationId = 0;
    public override Notification Create(Notification item)
    {
        item.notificationId = notificationId++;
        items.Add(notificationId,item);
        return item;
    }
    public List<Notification> GetNotificationByUserId(int userId)
    {
        return items.Where(x=>x.Value.userId == userId).Select(x=>x.Value).ToList();
    }
}