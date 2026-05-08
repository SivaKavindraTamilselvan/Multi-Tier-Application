using NotificationAppModelLibrary;
namespace NotificationAppBuisnessLayerLibrary.Interfaces;

public interface INotificationSender
{
    public void Send(string message,User user,string service);
}