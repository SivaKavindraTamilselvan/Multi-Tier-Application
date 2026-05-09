using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminNotificationRole
{
    public void DeliverNotificationByEmail()
    {
        string email = inputCheck.EmailInputs();
        var user = userService.GetUserByEmail(email);
        if (user == null)
        {
            Console.WriteLine($"No User Found With Email Address {email}");
            return;
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
            Console.WriteLine($"No User Found With Phone Number {phone}");
            return;
        }
        string message = inputCheck.MessageInputs(phone, "SMS");
        notificationService.SendNotificationToUsers(message, user, "SMS");
    }
}