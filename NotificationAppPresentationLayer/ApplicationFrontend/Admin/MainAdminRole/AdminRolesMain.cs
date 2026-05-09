using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminRole
{
    private readonly IUserService userService;
    private readonly INotificationService notificationService;
    private readonly AdminDeleteRole adminDeleteRole;
    private readonly AdminGetRole adminGetRole;
    private readonly AdminNotificationRole adminNotificationRole;
    private InputsCheck inputCheck = new InputsCheck();
    private AdminChoices console = new AdminChoices();
    public AdminRole(IUserService userService, INotificationService notificationService)
    {
        this.userService = userService;
        this.notificationService = notificationService;
        adminDeleteRole = new AdminDeleteRole(userService);
        adminGetRole = new AdminGetRole(userService);
        adminNotificationRole = new AdminNotificationRole(userService,notificationService);
    }
}