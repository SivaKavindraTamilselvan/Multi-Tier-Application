using NotificationAppModelLibrary;
using NotificationAppPresentationLayer.Role;
using DotNetEnv;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Services;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;

internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();

        IRepository<int, User> userRepo = new UserRepository();
        INotificationRepository notificationRepo = new NotificationRepository();

        INotificationSender email = new EmailService(notificationRepo);
        INotificationSender sms = new SMSService(notificationRepo);

        IUserService userService = new UserService(userRepo,email,sms);

        INotificationService notificationService =
            new NotificationService(notificationRepo, email, sms);

        AdminRole adminRole = new AdminRole(userService, notificationService);
        
        Company company = new Company();
        Console.WriteLine(company);

        while (true)
        {

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 For Company");
            Console.WriteLine("Enter 2 For User");
            Console.WriteLine("------------------------------------------------");
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) && typechoice != 1 && typechoice != 2)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            adminRole.AdminRoles();
                            return;
                        }
                    case 2:
                        {
                            return;
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