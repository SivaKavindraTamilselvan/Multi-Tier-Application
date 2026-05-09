using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class UserRole
{
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
    public void GetNotificationsByUserIdAndService(string service)
    {
        int userid = inputCheck.UserIdInputs();
        var user = userService.GetUserById(userid);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        notificationService.GetNotificationsByUserIdAndService(userid, service);
    }

}