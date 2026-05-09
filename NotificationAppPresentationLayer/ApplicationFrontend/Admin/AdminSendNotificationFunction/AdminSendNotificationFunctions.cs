using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminSendNotificationRole
{
    public void DeliverNotificationByEmail()
    {
        string email = inputCheck.EmailInputs();
        var user = userService.GetUserByEmail(email);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        string message = inputCheck.MessageInputs(email, "Email");
        notificationService.SendNotificationToUsers(message, user, "Email");
    }
    public void DeliverNotificationByPhoneNumber()
    {
        string phone = inputCheck.PhoneNumberInputs();
        var user = userService.GetUserByPhoneNumber(phone);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        string message = inputCheck.MessageInputs(phone, "SMS");
        notificationService.SendNotificationToUsers(message, user, "SMS");
    }
}