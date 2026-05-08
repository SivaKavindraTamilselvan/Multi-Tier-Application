using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;

namespace NotificationAppBuisnessLayerLibrary.Services;
public partial class UserService : IUserService
{
    public User? GetUserByPhoneNumber(string phonenumber)
    {
        var UserList = userRepo.GetAll();
        //if no user is registered
        if(UserList == null) return null;
        foreach (var item in UserList)
        {
            if (item.PhoneNumber == phonenumber)
            {
                return item;
            }
        }
        return null;
    }

    public List<User>? DeleteUserByPhoneNumber(string phonenumber)
    {
        var UserList = userRepo.GetAll();
        //if no user is registered
        if(UserList == null) return null;

        var deletedList = new List<User>();
        foreach (var item in UserList)
        {
            if (item.PhoneNumber == phonenumber)
            {
                var user = userRepo.Delete(item.userId);
                //if no user found
                if(user==null) return null;
                Console.WriteLine("User Deleted Successfully ! Wait for the Email && SMS to be sent");
                //sending the notification to the sms and email for deletion
                string message = $"Successfully deleted your account with the details\nName : {item.Name}\nPhoneNumber : {item.PhoneNumber}\nEmail : {item.Email}\n\nThank You!";
                emailService.Send(message, item);
                smsService.Send(message, item);
                deletedList.Add(item);
            }
        }
        if(deletedList.Count == 0)
        {
            return null;
        }
        return deletedList;
    }
}