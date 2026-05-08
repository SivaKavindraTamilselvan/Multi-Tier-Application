using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

public interface INotification
{
    void Send(string message,User user,string service);
    private void Log(string message,User user)
    {
        Console.WriteLine($"Log: {message} for {user.Name}");
    }
}