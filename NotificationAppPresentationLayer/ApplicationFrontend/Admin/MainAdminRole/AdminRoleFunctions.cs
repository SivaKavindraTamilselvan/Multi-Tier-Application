using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

namespace NotificationAppPresentationLayer.Application;

public partial class AdminRole
{
    public void AddUser()
    {
        var user = userService.AddUser();
        if (user == null) Console.WriteLine("User not added");
    }
    public void UpdateUser()
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
}