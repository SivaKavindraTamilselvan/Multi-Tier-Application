using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;


namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    INotificationSender emailService = new EmailService();
    INotificationSender smsService = new SMSService();
    IRepository<int, User> userRepo = new UserRepository();

    public void PrintAllUsers()
    {
        var UserList = userRepo.GetAll();
        //if no user found in the list
        if(UserList.Count == 0)
        {
            Console.WriteLine("No User Found");
            return;
        }
        foreach (var item in UserList)
        {
            Console.WriteLine(item);
        }
    }
}
