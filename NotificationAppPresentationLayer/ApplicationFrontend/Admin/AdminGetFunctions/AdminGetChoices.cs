using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetRole
{
    public void AdminGetRoles()
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
                    case 1:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.GetUserById(userid);
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the Email To Get The User");
                            //Inputs given and validated - check inputcheck file
                            string email = inputCheck.EmailInputs();
                            var user = userService.GetUserByEmail(email);
                            //display if no user with the email id found
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Email Address {email}");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the PhoneNumber To Get The User");
                            //Inputs given and validated - check inputcheck file
                            string phone = inputCheck.PhoneNumberInputs();
                            var user = userService.GetUserByPhoneNumber(phone);
                            //display if no user with the phone number found
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Phone Number {phone}");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 4:
                        {
                            userService.PrintAllUsers();
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