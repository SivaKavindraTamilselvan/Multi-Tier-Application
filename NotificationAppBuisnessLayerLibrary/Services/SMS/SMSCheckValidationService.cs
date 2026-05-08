using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Validation;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class SMSService : INotification
{
    
    private bool CheckValidation(User user)
    {
        return PhoneNumberValidation.isValidPhoneNumber(user.PhoneNumber??"");
    }
}