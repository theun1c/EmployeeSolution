using System.Net.Mail;

namespace EmployeeSolution.ConsoleApp.Services;

public class InputService
{
    public string GetStr(string textMessage)
    {
        while (true)
        {
            Console.WriteLine(textMessage);
            
            string input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.WriteLine("Pls try again. Incorrect input.");
        }
    }

    public int GetInt(string textMessage)
    {
        while (true)
        {
            Console.WriteLine(textMessage);
            
            if (int.TryParse(Console.ReadLine(), out int input) && (input >= 0 && input <= int.MaxValue))
            {
                return input;
            }

            Console.WriteLine("Pls try again. Number needs to be between 0 and 2147483647.");
        }
    }

    public decimal GetDecimal(string textMessage)
    {
        while (true)
        {
            Console.WriteLine(textMessage);

            if (decimal.TryParse(Console.ReadLine(), out decimal input) && (input >= 0 && input <= decimal.MaxValue))
            {
                return input;
            }
            
            Console.WriteLine("Pls try again. Number needs to be positive decimal.");
        }
    }

    public DateOnly GetDateOnly(string textMessage)
    {
        while (true)
        {
            Console.WriteLine(textMessage);

            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly input))
            {
                return input;
            }

            Console.WriteLine("Pls try again. Date format is yyyy-MM-dd");
        }
    }

    private bool IsEmail(string emailAddress)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
        {
            return false;
        }

        try
        {
            var email = new MailAddress(emailAddress);
            return email.Address == emailAddress;
        }
        catch
        {
            return false;
        }
    }
    
    public string GetEmail(string textMessage)
    {
        while (true)
        {
            Console.WriteLine(textMessage);
            
            
            string input = Console.ReadLine();

            if (IsEmail(input))
            {
                return input;
            }
            
            Console.WriteLine("Pls try again. Email needs to be a valid email address.");
        }
    }
}