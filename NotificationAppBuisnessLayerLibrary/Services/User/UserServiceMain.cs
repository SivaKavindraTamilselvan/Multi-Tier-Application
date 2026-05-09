using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    private readonly IRepository<int, User> userRepo;
    private readonly INotificationSender emailService;
    private readonly INotificationSender smsService;
    InputsCheck inputsCheck = new InputsCheck();
    public UserService(IRepository<int, User> repo,INotificationSender email,INotificationSender sms)
    {
        userRepo = repo;
        emailService = email;
        smsService = sms;
    }
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
