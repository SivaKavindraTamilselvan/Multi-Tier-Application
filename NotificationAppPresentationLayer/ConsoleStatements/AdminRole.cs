namespace NotificationAppPresentationLayer.Role;

public class AdminRoleConsole
{
    public void AdminConsoleChoice()
    {
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Add User");
        Console.WriteLine("Enter 2 To Deliver The Message To A User By Email");
        Console.WriteLine("Enter 3 To Deliver The Message To A User By Phone Number");

        Console.WriteLine("Enter 4 To Get User By Id");
        Console.WriteLine("Enter 5 To Get The User By Email");
        Console.WriteLine("Enter 6 To Get The User By PhoneNumber");
        Console.WriteLine("Enter 7 To Display All The Users");
        
        Console.WriteLine("Enter 8 To Delete User By Id");
        Console.WriteLine("Enter 9 To Delete The User By Email");
        Console.WriteLine("Enter 10 To Delete The User By PhoneNumber");

        Console.WriteLine("Enter 11 To Update User By Id");
        
        Console.WriteLine("Enter 12 To Display The Notification By Id");
        Console.WriteLine("Enter 13 To Display The Notification By User Id");
        Console.WriteLine("Enter 14 To Display All The Notification");
        
        
        Console.WriteLine("Enter 0 To Quit The Loop");
        Console.WriteLine("------------------------------------------------");
    }
}