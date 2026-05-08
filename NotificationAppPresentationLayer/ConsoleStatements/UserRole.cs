using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppModelLibrary;
using NotificationAppBuisnessLayerLibrary.Services;
using NotificationAppBuisnessLayerLibrary.Interfaces;
using NotificationAppDataAccessLibrary.Interfaces;
using NotificationAppBuisnessLayer.Inputs;

using DotNetEnv;
using System.Collections;
using System.Reflection.Metadata;
using NotificationAppPresentationLayer.ConsoleStatements;

namespace NotificationAppPresentationLayer.ConsoleStatements;

public class UserRole
{


    

    public void UserConsoleChoice()
    {
        int typechoice;
        while (!int.TryParse(Console.ReadLine(), out typechoice) || typechoice > 11 || typechoice < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        Console.WriteLine("------------------------------------------------");
        Console.WriteLine("Enter 1 To Get The Notification Sent To My Email");
        Console.WriteLine("Enter 2 To Get The Notification Sent To My Phone Number");
        try
        {
            switch (typechoice)
            {
                case 1:
                    {
                        
                        break;
                    }
                case 2:
                    {
                        
                        break;
                    }
                case 3:
                    {
                       
                        break;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}