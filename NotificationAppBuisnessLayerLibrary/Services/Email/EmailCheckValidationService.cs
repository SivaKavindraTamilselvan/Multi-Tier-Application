using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Validation;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class EmailService : INotification
{
    private bool CheckValidation(User user)
    {
        return EmailValidation.isValidEmail(user.Email??"");
    }
}