using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class NotificationService : INotificationService
{
    public Notification? GetNotificationsById(int id)
    {
        return notificationRepo.Get(id);
    }

    public void GetNotificationsByUserId(int id)
    {
        var notification = notificationRepo.GetNotificationByUserId(id);
        if (notification.Count == 0)
        {
            throw new NotificationNotFoundException();
        }
        foreach (var item in notification)
        {
            Console.WriteLine("Notification Information");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }

    public void GetNotificationsByUserIdAndService(int userId, string service)
    {
        var notification = notificationRepo.GetNotificationsByUserIdAndService(userId, service);
        if (notification.Count == 0)
        {
            throw new NotificationNotFoundException();
        }
        foreach (var item in notification)
        {
            Console.WriteLine("Notification Information");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
    public void GetNotificationsByService(string service)
    {
        var notification = notificationRepo.GetNotificationsByService(service);
        if (notification.Count == 0)
        {
            throw new NotificationNotFoundException();
        }
        foreach (var item in notification)
        {
            Console.WriteLine("Notification Information");
            Console.WriteLine(item);
            Console.WriteLine();
        }
    }
}