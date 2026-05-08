using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Services;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

using DotNetEnv;
using System.Collections;
using System.Reflection.Metadata;
using NotificationAppPresentationLayer.ConsoleStatements;

namespace NotificationAppPresentationLayer.ConsoleStatements;

public class UserRole
{


    //display the company details from the model
    //user service object created to handle every user services
    IUserService userService = new UserService();
    //used for inputs displaying to avoid repeated code
    InputsCheck inputCheck = new InputsCheck();

    public void UserConsoleChoice()
    {
        int typechoice;
        while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 11 || typechoice < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Get The Notification Sent To My Email");
        Console.WriteLine("Enter 2 To Get The Notification Sent To My Phone Number");
        try
        {
            switch (typechoice)
            {
                case 1:
                    {
                        var user = userService.AddUser();
                        //this condition is applied if user registering with aldready registered email id
                        if (user == null) Console.WriteLine("User not added");
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
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}