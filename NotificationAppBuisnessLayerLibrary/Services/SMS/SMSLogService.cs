using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class SMSService : NotificationService
{
    //log the information in console
    public override void LogNotification()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Logging the Information - SMS Service");
        Console.WriteLine($"The SMS Services\nFrom : sivakavindra@gmail.com\nTo : {user.Email}\nStatus : {status}\nDate & Time : {dateTime}\nMessage : {message}");
        Console.WriteLine("---------------------------------------------");
    }
}