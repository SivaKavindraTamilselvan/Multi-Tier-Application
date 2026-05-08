using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Interfaces;

namespace NotificationAppBuisnessLayerLibrary.Services;
public partial class UserService : IUserService
{
    public User? GetUserById(int id)
    {
        return userRepo.Get(id);
    }
    public User? DeleteUserById(int id)
    {
        deletedUser = userRepo.Get(id);
        DeleteDelegate();
        return deletedUser;
    }
    public User? UpdateUserById(int userId)
    {
        updateUser = GetUserById(userId);
        if (updateUser == null)
        {
            return null;
        }
        UpdateDelegate();

        return updateUser;
    }
}