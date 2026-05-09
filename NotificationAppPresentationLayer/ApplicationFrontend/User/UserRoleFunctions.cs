using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class UserRole
{
    public void GetNotificationsByUserId()
    {
        int userid = inputCheck.IdInputs();
        var user = userService.GetUserById(userid);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        notificationService.GetNotificationsByUserId(userid);
    }
    public void GetNotificationsByUserIdAndService(string service)
    {
        int userid = inputCheck.IdInputs();
        var user = userService.GetUserById(userid);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        notificationService.GetNotificationsByUserIdAndService(userid, service);
    }

}