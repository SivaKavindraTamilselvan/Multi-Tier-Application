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
                deletedUser = item;
                DeleteDelegate();
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