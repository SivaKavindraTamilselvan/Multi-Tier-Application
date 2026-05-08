using NotificationAppModelLibrary;
using NotificationAppPresentationLayer.Role;
using DotNetEnv;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Repositories;


internal class Program
{
    static void Main(string[] args)
    {
        Env.Load();


        //display the company details from the models
        Company company = new Company();
        Console.WriteLine(company);
        AdminRole adminRole = new AdminRole();
        while (true)
        {

            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Enter 1 For Company");
            Console.WriteLine("Enter 2 For User");
            Console.WriteLine("------------------------------------------------");
            int typechoice;
            while (!int.TryParse(Console.ReadLine(), out typechoice) && typechoice!=1 && typechoice !=2)
            {
                Console.WriteLine("Enter Vaild Input");
            }
            try
            {
                switch (typechoice)
                {
                    case 1:
                        {
                            adminRole.AdminRoles();
                            return;
                        }
                    case 2:
                        {
                            return;
                        }
                    case 0:
                        {
                            return;
                        }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}