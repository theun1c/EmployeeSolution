using System.Net.Mail;

namespace EmployeeSolution.ConsoleApp.Services;

/// <summary>
/// class for validation inputs 
/// </summary>
public class InputService
{
    // string validation 
    public string? GetStr(string textMessage, bool isRequired = true)
    {
        while (true)
        {
            Console.WriteLine(textMessage);
            
            if (!isRequired)
            {
                Console.WriteLine( " *optional parameter* " );
            }
            
            string input = Console.ReadLine()?.Trim();

            if (!isRequired && string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Field is required");
                continue;
            }
            
            return input;
        }
    }

    // int validation
    public int? GetInt(string textMessage, bool isRequired = true)
    {
        while (true)
        {
            Console.WriteLine(textMessage);

            if (!isRequired)
            {
                Console.Write( "*optional parameter* ");
            }
            
            string input = Console.ReadLine()?.Trim();


            if (!isRequired && string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Field is required.");
                continue;
            }
            
            if (int.TryParse(input, out int result) && (result >= 0))
            {
                return result;
            }

            Console.WriteLine("Pls try again. Number needs to be between 0 and 2147483647.");
        }
    }

    // decimal validation
    public decimal? GetDecimal(string textMessage, bool isRequired = true)
    {
        while (true)
        {
            Console.WriteLine(textMessage);
            
            if (!isRequired)
            {
                Console.Write( " *optional parameter* " );
            }
            
            string input = Console.ReadLine()?.Trim();

            if (!isRequired && string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Field is required.");
                continue;
            }
            
            if (decimal.TryParse(input, out decimal number) && (number >= 0 && number <= decimal.MaxValue))
            {
                return number;
            }
            
            Console.WriteLine("Pls try again. Number needs to be positive decimal.");
        }
    }

    // date validation
    public DateOnly? GetDateOnly(string textMessage, bool isRequired = true)
    {
        while (true)
        {
            Console.WriteLine(textMessage);

            if (!isRequired)
            {
                Console.Write( "*optional parameter* " );
            }

            string input = Console.ReadLine()?.Trim();

            if (!isRequired && string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
            
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Date is required.");
                continue;
            }
            
            if (DateOnly.TryParse(input, out DateOnly dateOnly))
            {
                if (dateOnly > DateOnly.FromDateTime(DateTime.Today))
                {
                    Console.WriteLine("Date cannot be in the future. Please enter a valid date.");
                    continue;
                }
                return dateOnly;
            }

            Console.WriteLine("Pls try again. Date format is yyyy-MM-dd");
        }
    }

    // email validation helps method
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
    
    // email str validation
    public string GetEmail(string textMessage, bool isRequired = true)
    {
        
        while (true)
        {
            Console.WriteLine(textMessage);

            if (!isRequired)
            {
                Console.Write( "*optional parameter* " );
            }
            
            string input = Console.ReadLine();

            if (!isRequired && string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }
            
            if (IsEmail(input))
            {
                return input;
            }
            
            Console.WriteLine("Pls try again. Email needs to be a valid email address.");
        }
    }
}