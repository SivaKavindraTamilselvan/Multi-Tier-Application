using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetNotificationRole
{
    public void GetNotificationsById()
    {
        int userid = inputCheck.UserIdInputs();

        var notification = notificationService.GetNotificationsById(userid);
        if (notification == null)
        {
            Console.WriteLine("No notifications found");
            return;
        }
        Console.WriteLine(notification);
    }
    public void GetNotificationsByUserId()
    {
        int userid = inputCheck.UserIdInputs();
        var user = userService.GetUserById(userid);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        notificationService.GetNotificationsByUserId(userid);
    }
    public void GetAllNotification()
    {
        notificationService.PrintAllNotification();
    }
}