using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppDataAccessLibrary.Repositories;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Delegates;

namespace NotificationAppBuisnessLayerLibrary.Services;

public abstract class NotificationService : INotification
{
    IRepository<int,Notification> notificationRepo = new NotificationRepository();
    MessageValidation validation = new MessageValidation();
    NotificationOperation? notificationOperation;

    protected string message = "";
    protected User user=null!;
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
        notificationOperation += SaveNotification;
        notificationOperation += LogNotification;

        notificationOperation?.Invoke();
    }
    public void ValidationOfMessage()
    {
        validation.ValidateMessage(message,service);
    }
    public void SaveNotification()
    {
        Notification notification = new Notification();
        notification.userId = user.userId;
        notification.datetime = dateTime;
        notification.message=message;
        notification.service=service;
        notificationRepo.Create(notification);
    }
    public abstract void LogNotification();
}