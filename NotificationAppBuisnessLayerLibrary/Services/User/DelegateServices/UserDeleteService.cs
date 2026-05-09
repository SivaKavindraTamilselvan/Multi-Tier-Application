using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppBuisnessLayerLibrary.Delegates;


namespace NotificationAppBuisnessLayerLibrary.Services;

public partial class UserService : IUserService
{
    DeleteUserOperation? deleteUserOperation;
    private User deletedUser = null!;
    public void DeleteDelegate()
    {
        deleteUserOperation = null;

        deleteUserOperation += DeleteUser;
        deleteUserOperation += SendDeleteNotification;

        deleteUserOperation?.Invoke();
        Console.WriteLine("User Deleted Successfully ! Wait for the Email && SMS to be sent");
    }
    public void DeleteUser()
    {
        userRepo.Delete(deletedUser.userId);
    }
    public void SendDeleteNotification()
    {
        string message = $"Successfully deleted your account with the details\nName : {deletedUser.Name}\nPhoneNumber : {deletedUser.PhoneNumber}\nEmail : {deletedUser.Email}\n\nThank You!";
        emailService.Send(message, deletedUser,"Email");
        smsService.Send(message, deletedUser,"SMS");
    }
}