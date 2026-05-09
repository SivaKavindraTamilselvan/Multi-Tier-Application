using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminNotificationRole
{
        public void AdminNotificationRoles()
    {
        while (true)
        {
            //console.DisplayAdminChoices();
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 14 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 2:
                        {
                            string email = inputCheck.EmailInputs();
                            var user = userService.GetUserByEmail(email);
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Email Address {email}");
                                break;
                            }
                            string message = inputCheck.MessageInputs(email, "Email");
                            notificationService.SendNotificationToUsers(message, user, "Email");
                            break;
                        }
                    case 3:
                        {

                            string phone = inputCheck.PhoneNumberInputs();
                            var user = userService.GetUserByPhoneNumber(phone);
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Phone Number {phone}");
                                break;
                            }
                            string message = inputCheck.MessageInputs(phone, "SMS");
                            notificationService.SendNotificationToUsers(message, user, "SMS");
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