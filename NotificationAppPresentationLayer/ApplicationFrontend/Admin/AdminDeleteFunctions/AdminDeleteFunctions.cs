using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminDeleteRole
{
    public void DeleteUserByEmail()
    {
        Console.WriteLine("Enter the Email To Delete The User");
        //Inputs given and validated - check inputcheck file
        string email = inputCheck.EmailInputs();
        var user = userService.DeleteUserByEmail(email);
        //display if no user with the email id found
        if (user == null)
        {
            Console.WriteLine($"No User Found With Email Address {email}");
            return;
        }
        Console.WriteLine(user);
    }
    public void DeleteUserById()
    {
        int userid = inputCheck.UserIdInputs();
        var user = userService.DeleteUserById(userid);
        //display if no user with the id found
        if (user == null)
        {
            Console.WriteLine("User not found");
            return;
        }
        Console.WriteLine(user);
    }
    public void DeleteUserByPhoneNumber()
    {
        Console.WriteLine("Enter the PhoneNumber To Delete The User");
        //Inputs given and validated - check inputcheck file
        string phone = inputCheck.PhoneNumberInputs();
        var user = userService.DeleteUserByPhoneNumber(phone);
        //display if no user with the phone number found
        if (user == null)
        {
            Console.WriteLine($"No User Found With Phone Number {phone}");
            return;
        }
        Console.WriteLine("Deleted User List With Phone Number");
        foreach (var item in user)
        {
            Console.WriteLine(item);
        }
    }
}