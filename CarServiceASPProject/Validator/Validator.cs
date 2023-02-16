using System.Text.RegularExpressions;

namespace CarServiceProject.Validator;

public static class Validator
{
    public static bool ValidatePhone(string value)
    {
        var phoneRegex = new Regex(@"((\+38|8|\+3|\+ )[ ]?)?([(]?\d{3}[)]?[\- ]?)?(\d[ -]?){6,14}");
        return phoneRegex.IsMatch(value);
    }

    public static bool ValidatePassword(string password)
    {
        return password.Length >= 6;
    }
}