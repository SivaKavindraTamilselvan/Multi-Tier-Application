using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminNotificationRole
{
    private readonly IUserService userService;
    private readonly INotificationService notificationService;
    private InputsCheck inputCheck = new InputsCheck();
    private AdminChoices console = new AdminChoices();
    public AdminNotificationRole(IUserService userService, INotificationService notificationService)
    {
        this.userService = userService;
        this.notificationService = notificationService;
    }
}