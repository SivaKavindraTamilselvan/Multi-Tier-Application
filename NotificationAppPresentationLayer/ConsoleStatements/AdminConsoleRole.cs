using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Services;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;
using NotificationAppDataAccessLibrary.Interfaces;
using DotNetEnv;
using System.Collections;
using System.Reflection.Metadata;
using NotificationAppPresentationLayer.ConsoleStatements;

namespace NotificationAppPresentationLayer.Role;

public class AdminRole
{

    IUserService userService = new UserService();
    NotificationClass notificationClass = new NotificationClass();
    InputsCheck inputCheck = new InputsCheck();
    AdminRoleConsole console = new AdminRoleConsole();
    public void AdminRoles()
    {
        while (true)
        {
            console.AdminConsoleChoice();
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
                            var user = userService.AddUser();
                            if (user == null) Console.WriteLine("User not added");
                            break;
                        }
                    case 2:
                        {
                            
                            string email = inputCheck.EmailInputs();
                            var user = userService.GetUserByEmail(email);
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Email Address {email}");
                                break;
                            }
                            string message = inputCheck.MessageInputs(email,"Email");
                            notificationClass.SendNotificationToUsers(message, user, "Email");
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
                            string message = inputCheck.MessageInputs(phone,"SMS");
                            notificationClass.SendNotificationToUsers(message, user, "SMS");
                            break;
                        }
                    case 4:
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
                    case 5:
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
                    case 6:
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
                    case 7:
                        {
                            userService.PrintAllUsers();
                            break;
                        }
                    case 8:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.DeleteUserById(userid);
                            //display if no user with the id found
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine("Enter the Email To Delete The User");
                            //Inputs given and validated - check inputcheck file
                            string email = inputCheck.EmailInputs();
                            var user = userService.DeleteUserByEmail(email);
                            //display if no user with the email id found
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Email Address {email}");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine("Enter the PhoneNumber To Delete The User");
                            //Inputs given and validated - check inputcheck file
                            string phone = inputCheck.PhoneNumberInputs();
                            var user = userService.DeleteUserByPhoneNumber(phone);
                            //display if no user with the phone number found
                            if (user == null)
                            {
                                Console.WriteLine($"No User Found With Phone Number {phone}");
                                break;
                            }
                            Console.WriteLine("Deleted User List With Phone Number");
                            foreach (var item in user)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        }
                    case 11:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.UpdateUserById(userid);
                            //display if no user with the id found
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 12:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var notification = notificationClass.GetNotificationsById(userid);
                            if (notification == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            Console.WriteLine(notification);
                            break;
                        }
                    case 13:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var notification = notificationClass.GetNotificationsByUserId(userid);
                            if (notification == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            Console.WriteLine(notification);
                            break;
                        }
                    case 14:
                        {
                            notificationClass.PrintAllNotification();
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