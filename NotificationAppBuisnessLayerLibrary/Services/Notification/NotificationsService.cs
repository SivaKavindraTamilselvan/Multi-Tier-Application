
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;
using NotificationAppModelLibrary;

namespace NotificationAppBuisnessLayerLibrary.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository notificationRepo;
    private readonly INotificationSender email;
    private readonly INotificationSender sms;
    public NotificationService(INotificationRepository _notificationRepo,INotificationSender _email,INotificationSender _sms)
    {
        notificationRepo = _notificationRepo;
        email = _email;
        sms = _sms;
    }
    public void SendNotificationToUsers(string message,User user,string service)
    {
        if(service == "Email")
        {
            //CreateNotification(message,user,service);
            email.Send(message,user,service);
            Console.WriteLine("Wait Untill the Email Notification is Sent");
        }
        else if(service == "SMS")
        {
            //CreateNotification(message,user,service);
            sms.Send(message,user,service);
            Console.WriteLine("Wait Untill the SMS Notification is Sent");
        }
        else
        {
            Console.WriteLine("No Valid Service method entered");
        }
    }
    public void PrintAllNotification()
    {
        var NotificationList = notificationRepo.GetAll();
        if(NotificationList.Count == 0)
        {
            Console.WriteLine("No User Found");
            return;
        }
        foreach (var item in NotificationList)
        {
            Console.WriteLine(item);
        }
    }

    public Notification? GetNotificationsById(int id)
    {
        return notificationRepo.Get(id);
    }

    public List<Notification> GetNotificationsByUserId(int id)
    {
        return notificationRepo.GetNotificationByUserId(id);
    }

    public void CreateNotification(string message,User user,string service)
    {
        Notification notification = new Notification();
        notification.userId = user.userId;
        notification.datetime = DateTime.Now;
        notification.message=message;
        notification.service=service;
        notificationRepo.Create(notification);
    }
}