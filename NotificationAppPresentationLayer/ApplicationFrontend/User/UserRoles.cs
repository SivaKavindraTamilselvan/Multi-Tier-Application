using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public class UserRole
{
    private readonly IUserService userService;
    private readonly INotificationService notificationService;
    private InputsCheck inputCheck = new InputsCheck();
    private UserChoices console = new UserChoices();
    public UserRole(IUserService userService, INotificationService notificationService)
    {
        this.userService = userService;
        this.notificationService = notificationService;
    }
    public void UserRoles()
    {
        while (true)
        {
            console.DisplayUserChoices();
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 3 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.GetUserById(userid);
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            notificationService.GetNotificationsByUserIdAndService(userid,"Email");
                            break;
                        }
                    case 2:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.GetUserById(userid);
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            notificationService.GetNotificationsByUserIdAndService(userid,"SMS");
                            break;
                        }
                    case 3:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.GetUserById(userid);
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            notificationService.GetNotificationsByUserId(userid);
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}