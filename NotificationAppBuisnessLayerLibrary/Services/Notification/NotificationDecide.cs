
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;
using NotificationAppModelLibrary;

namespace NotificationAppBuisnessLayerLibrary.Services;

public class NotificationClass : INotification
{
    NotificationRepository notificationRepo = new NotificationRepository();
    public void SendNotificationToUsers(string message,User user,string service)
    {
        if(service == "Email")
        {
            INotificationSender emailService = new EmailService();
            emailService.Send(message,user,service);
            Console.WriteLine("Wait Untill the Email Notification is Sent");
        }
        else if(service == "SMS")
        {
            INotificationSender smsService = new SMSService();
            smsService.Send(message,user,service);
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
        //if no user found in the list
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

    public void CreateNotification(Notification item)
    {
        var notification =  notificationRepo.Create(item);
    }
}