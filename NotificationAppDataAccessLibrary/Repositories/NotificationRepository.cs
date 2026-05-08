using NotificationAppModelLibrary;

namespace NotificationAppDataAccessLibrary.Repositories;

public class NotificationRepository : AbstractRepository<int,Notification>,INotificationRepository
{
    static int notificationId = 0;
    public override Notification Create(Notification item)
    {
        item.notificationId = notificationId++;
        items.Add(notificationId,item);
        Console.WriteLine("jj");
        return item;
    }
    public List<Notification> GetNotificationByUserId(int userId)
    {
        return items.Values
                    .Where(x => x.userId == userId)
                    .ToList();
    }
}