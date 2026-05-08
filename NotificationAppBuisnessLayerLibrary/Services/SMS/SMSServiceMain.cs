using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;

namespace NotificationAppBuisnessLayerLibrary.Services;

//partial class imolemented to avoid long code
public partial class SMSService : NotificationService
{
    //just implement console based message service
    public override void SendNotification()
    {
       dateTime = DateTime.Now;
       Console.WriteLine("MessageService");
       Console.WriteLine("From - 944237XXXX");
       Console.WriteLine($"To - {user.PhoneNumber}");
       Console.WriteLine($"Date - {dateTime}");
       Console.WriteLine($"Message - {message}");
       status = "sent";
       Console.WriteLine("SMS Sent Successfully");
    }
}