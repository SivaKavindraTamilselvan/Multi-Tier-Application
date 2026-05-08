namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class EmailService : NotificationSenderService 
{
    public override void LogNotification()
    {
        Console.WriteLine("---------------------------------------------");
        Console.WriteLine("Logging the Information - Email Service");
        Console.WriteLine($"The Email Services\nFrom : sivakavindra@gmail.com\nTo : {user.Email}\nStatus : {status}\nDate & Time : {dateTime}\nMessage : {message}");
        Console.WriteLine("---------------------------------------------"); 
    }
}