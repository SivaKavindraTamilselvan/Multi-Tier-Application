namespace NotificationAppPresentationLayer.Application;
public partial class AdminRole
{
    public void AdminRoles()
    {
        while (true)
        {
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 5 || typechoice < 0)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            var user = userService.AddUser();
                            if (user == null) Console.WriteLine("User not added");
                            break;
                        }
                    case 2:
                        {
                            adminGetRole.AdminGetRoles();
                            break;
                        }
                    case 3:
                        {
                            int userid = inputCheck.UserIdInputs();
                            var user = userService.UpdateUserById(userid);
                            //display if no user with the id found
                            if (user == null)
                            {
                                Console.WriteLine("User not found");
                                break;
                            }
                            Console.WriteLine(user);
                            break;
                        }
                    case 4:
                        {
                            adminDeleteRole.AdminDeleteRoles();
                            break;
                        }
                    case 5:
                        {
                            adminNotificationRole.AdminNotificationRoles();
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}