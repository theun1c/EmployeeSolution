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

    //
    // CREATE
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

    //
    // GET ALL 
    public List<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }
    
    //
    // UPDATE
    public int UpdateEmployeeById(int employeeId, string firstName, string lastName, string email, DateOnly dateOfBirth, decimal salary)
    {
        var employee = _context.Employees.Find(employeeId);
        if (employee != null)
        {
            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.DateOfBirth = dateOfBirth;
            employee.Salary = salary;
            _context.SaveChanges();
        }
        
        return employee.EmployeeId;
    }
}