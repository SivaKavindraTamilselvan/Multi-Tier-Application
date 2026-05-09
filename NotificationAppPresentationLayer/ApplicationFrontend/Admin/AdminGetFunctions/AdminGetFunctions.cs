using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminGetRole
{
    public void GetUserById()
    {
        int userid = inputCheck.UserIdInputs();
        var user = userService.GetUserById(userid);
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        Console.WriteLine(user);
    }
    public void GetUserByEmail()
    {
        Console.WriteLine("Enter the Email To Get The User");
        //Inputs given and validated - check inputcheck file
        string email = inputCheck.EmailInputs();
        var user = userService.GetUserByEmail(email);
        //display if no user with the email id found
        if (user == null)
        {
            Console.WriteLine($"No User Found With Email Address {email}");
            return;
        }
        Console.WriteLine(user);
    }
    public void GetUserByPhoneNumber()
    {
        Console.WriteLine("Enter the PhoneNumber To Get The User");
        //Inputs given and validated - check inputcheck file
        string phone = inputCheck.PhoneNumberInputs();
        var user = userService.GetUserByPhoneNumber(phone);
        //display if no user with the phone number found
        if (user == null)
        {
            Console.WriteLine($"No User Found With Phone Number {phone}");
            return;
        }
        Console.WriteLine(user);
    }
    public void GetAll()
    {
        userService.PrintAllUsers();
    }
}