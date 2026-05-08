using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppBuisnessLayerLibrary.Delegates;

namespace NotificationAppBuisnessLayerLibrary.Services;

public abstract class NotificationSenderService : INotificationSender
{
    private readonly INotificationRepository notificationRepo;
    public NotificationSenderService(INotificationRepository _notificationRepo)
    {
        notificationRepo = _notificationRepo;
    }
    NotificationOperation? notificationOperation;

    protected string message = "";
    protected User user = null!;
    protected string service = "";

    protected string? status;
    protected DateTime? dateTime;

    public abstract void SendNotification();
    public void Send(string message, User user, string service)
    {
        this.message = message;
        this.user = user;
        this.service = service;

        // Clear old delegates
        notificationOperation = null;

        notificationOperation += ValidationOfMessage;
        notificationOperation += SendNotification;
        notificationOperation += Log;
        notificationOperation += LogNotification;

        notificationOperation?.Invoke();
    }
    public void ValidationOfMessage()
    {
        MessageValidation.ValidateMessage(message, service);
    }

    public void Log()
    {
        Notification notification = new Notification
        {
            userId = user.userId,
            message = message,
            service = service,
            status = status,
            datetime = DateTime.Now
        };

        notificationRepo.Create(notification);
    }

    public abstract void LogNotification();
}