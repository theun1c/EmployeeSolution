using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Models;

namespace EmployeeSolution.ConsoleApp.Services;

public class EmployeeService
{
    private readonly EmployeeDbContext _context;

    public EmployeeService(EmployeeDbContext context)
    {
        _context = context;
    }

    public int CreateEmployee(string firstName, string lastName, string email, DateOnly dateOfBirth, decimal salary)
    {
        var employee = new Employee
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            DateOfBirth = dateOfBirth,
            Salary = salary
        };
        
        _context.Employees.Add(employee);
        _context.SaveChanges();
        
        return employee.EmployeeId; 
    }

    public List<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }
}