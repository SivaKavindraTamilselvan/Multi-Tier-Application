using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class SMSService : NotificationSenderService
{
    public SMSService(INotificationRepository repo) : base(repo)
    {
    }
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