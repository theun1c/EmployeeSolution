using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Models;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeSolution.ConsoleApp.Services;

public class EmployeeService
{
    private readonly EmployeeDbContext _context;

    //
    // ctor 
    public EmployeeService(EmployeeDbContext context)
    {
        _context = context;
    }

    //
    // CREATE
    public int CreateEmployee(string firstName, string lastName, string email, DateOnly? dateOfBirth, decimal? salary)
    {
        var employee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            DateOfBirth = dateOfBirth.Value,
            Salary = salary.Value
        };
        
        _context.Employees.Add(employee);
        _context.SaveChanges();
        
        return employee.EmployeeId; 
    }

    //
    // GET ALL EMP
    public List<Employee> GetAllEmployees()
    {
        if (!_context.Employees.Any())
            return new List<Employee>();
        
        return _context.Employees.ToList();
    }
    
    //
    // GET ALL EMP WITH HIGHT SALARY
    public List<Employee> GetEmploeesByAVGSalary()
    {
        if (!_context.Employees.Any())
            return new List<Employee>();

        decimal avgSalary = _context.Employees.Average(x => x.Salary);
        return _context.Employees.Where(x => x.Salary > avgSalary).ToList();
    }

    public Employee GetEmployeeById(int employeeId)
    {
        return _context.Employees.FirstOrDefault(x => x.EmployeeId == employeeId);
    }
    
    //
    // UPDATE :id
    public int UpdateEmployeeById(int? employeeId, string? firstName = null, string? lastName = null, string? email = null, DateOnly? dateOfBirth = null, decimal? salary = null)
    {
        var employee = _context.Employees.Find(employeeId);
        if (employee == null)
        {
            Console.WriteLine("Cannot find employee.");
            return -1;
        }

        if (!string.IsNullOrEmpty(firstName))
            employee.FirstName = firstName;
        
        if (!string.IsNullOrEmpty(lastName))
            employee.LastName = lastName;
        
        if (!string.IsNullOrEmpty(email))
            employee.Email = email;
        
        if (dateOfBirth != null)
            employee.DateOfBirth = dateOfBirth.Value;
        
        if (salary != null)
            employee.Salary = salary.Value;
        
        _context.SaveChanges();
        
        return employee.EmployeeId;
    }
    
    //
    // DELETE :id
    public bool DeleteEmployeeById(int employeeId)
    {
        var employee = GetEmployeeById(employeeId);
        if (employee == null)
            return false; // Сотрудник не найден
    
        _context.Employees.Remove(employee);
        _context.SaveChanges();
        return true; // Успешно удален
    }
}