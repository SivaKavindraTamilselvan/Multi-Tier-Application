using System.Text.RegularExpressions;
using NotificationAppModelLibrary.Exceptions;

namespace NotificationAppBuisnessLayerLibrary.Validation;

public class EmailValidation
{
    //implementation of email validation by using regex pattern
    public static bool isValidEmail(string email)
    {
        string checkEmail=email.Trim();

        if(checkEmail==null || checkEmail=="")
        {
            return false;
        }
        //regex pattern
        string pattern=@"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if(!Regex.IsMatch(checkEmail, pattern, RegexOptions.IgnoreCase)){
            throw new EmailException("Email Entered Is Not Valid. Your Account is Not Created");
        }
        return Regex.IsMatch(checkEmail, pattern, RegexOptions.IgnoreCase);
        
    }
}