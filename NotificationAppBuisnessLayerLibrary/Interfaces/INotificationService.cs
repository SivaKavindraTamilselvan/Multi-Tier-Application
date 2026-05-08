using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

public interface INotification
{
    void Send(string message,User user);
    private bool CheckValidation(User user)
    {
        return user != null;
    }
    private void Log(string message,User user)
    {
        Console.WriteLine($"Log: {message} for {user.Name}");
    }
}