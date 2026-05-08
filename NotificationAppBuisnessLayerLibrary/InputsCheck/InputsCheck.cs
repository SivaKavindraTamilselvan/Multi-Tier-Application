using NotificationAppBuisnessLayerLibrary.Validation;
using NotificationAppModelLibrary;

namespace NotificationAppBuisnessLayer.Inputs;

public class InputsCheck
{
    //program.cs inputs and console.writeline is used
    public string EmailInputs()
    {
        string email = Console.ReadLine() ?? string.Empty;

        while(true)
        {
            try
            {
                EmailValidation.isValidEmail(email);
                return email;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Email Address Again");
                email = Console.ReadLine() ?? "";
            }
        }
    }
    public string PhoneNumberInputs()
    {
        string phone = Console.ReadLine() ?? string.Empty;

        while (true)
        {
            try
            {
                PhoneNumberValidation.isValidPhoneNumber(phone);
                return phone;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Phone Number Again");
                phone = Console.ReadLine() ?? "";
            }
        }
    }

    public string MessageInputs(string receiver, string service)
    {
        Console.WriteLine($"Enter Message To Send To {receiver}");

        string message = Console.ReadLine() ?? string.Empty;

        while (true)
        {
            try
            {
                MessageValidation.ValidateMessage(message, service);
                return message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Enter Valid Message Again");
                message = Console.ReadLine() ?? "";
            }
        }
    }

    public int UserIdInputs()
    {
        Console.WriteLine("Enter UserId");
        int userid;
        while (!int.TryParse(Console.ReadLine(), out userid) || userid < 0)
        {
            Console.WriteLine("Enter Vaild Input");
        }
        return userid;
    }
}