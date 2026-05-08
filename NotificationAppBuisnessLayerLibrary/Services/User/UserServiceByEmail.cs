using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;

namespace NotificationAppBuisnessLayerLibrary.Services;
public partial class UserService : IUserService
{
    public User? GetUserByEmail(string email)
    {
        var UserList = userRepo.GetAll();
        if(UserList == null) return null;
        foreach (var item in UserList)
        {
            if (item.Email == email)
            {
                return item;
            }
        }
        return null;
    }
    public User? DeleteUserByEmail(string email)
    {
        var UserList = userRepo.GetAll();
        if(UserList == null) return null;
        foreach (var item in UserList)
        {
            if (item.Email == email)
            {
                deletedUser = item;
                DeleteDelegate();
                return deletedUser;
            }
        }
        return null;
    }
}
