using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetNotificationRole
{
    public void AdminGetNotificationRoles()
    {
        while (true)
        {
            adminChoices.DisplayAdminNotificationChoices();
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 14 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 12:
                        {
                            GetNotificationsById();
                            break;
                        }
                    case 13:
                        {
                            GetNotificationsByUserId();
                            break;
                        }
                    case 14:
                        {
                            GetAllNotification();
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