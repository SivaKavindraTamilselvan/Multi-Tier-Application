
using System.Data.Common;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;
using NotificationAppModelLibrary;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository notificationRepo;
    private readonly INotificationSender email;
    private readonly INotificationSender sms;
    public NotificationService(INotificationRepository _notificationRepo, INotificationSender _email, INotificationSender _sms)
    {
        notificationRepo = _notificationRepo;
        email = _email;
        sms = _sms;
    }
    public void SendNotificationToUsers(string message, User user, string service)
    {
        if (service == "Email")
        {
            //CreateNotification(message,user,service);
            email.Send(message, user, service);
            Console.WriteLine("Wait Untill the Email Notification is Sent");
        }
        else if (service == "SMS")
        {
            //CreateNotification(message,user,service);
            sms.Send(message, user, service);
            Console.WriteLine("Wait Untill the SMS Notification is Sent");
        }
        else
        {
            Console.WriteLine("No Valid Service method entered");
        }
    }
    public void PrintAllNotification()
    {
        var notificationList = notificationRepo.GetAll();

        if (notificationList.Count == 0)
        {
            throw new NotificationNotFoundException();
        }

        foreach (var item in notificationList)
        {
            Console.WriteLine(item);
        }
    }
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
            Console.WriteLine(item);
        }
    }

    public void CreateNotification(string message, User user, string service)
    {
        Notification notification = new Notification();
        notification.userId = user.userId;
        notification.datetime = DateTime.Now;
        notification.message = message;
        notification.service = service;
        notificationRepo.Create(notification);
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
            Console.WriteLine(item);
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
            Console.WriteLine(item);
        }
    }
}