using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Services;

namespace EmployeeSolution.ConsoleApp.UI;

public class ConsoleMenu
{
   
    private readonly EmployeeService _employeeService;
    private readonly InputService _inputService;

    public ConsoleMenu(EmployeeService employeeService, InputService inputService)
    {
        _employeeService = employeeService;
        _inputService = inputService;
    }
    
     private void AddEmployee()
        {
            string firstName = _inputService.GetStr("Enter first name: ");
            string lastName = _inputService.GetStr("Enter last name: ");
            string email = _inputService.GetEmail("Enter email: ");
            DateOnly? dateOfBirth = _inputService.GetDateOnly("Enter date of birth: ");
            decimal? salary = _inputService.GetDecimal("Enter salary: ");
            
            _employeeService.CreateEmployee(firstName, lastName, email, dateOfBirth, salary);

            Console.WriteLine("Employee added successfully.\nPress any key to continue...");
            Console.ReadKey();
        }

        private void ViewAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            foreach (var e in employees)
            {
                Console.WriteLine(e.EmployeeId + " " + e.FirstName + " " + e.LastName + " " + e.Email + " " + e.DateOfBirth + " " + e.Salary);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void ViewEmployeesAVGSalaryCount()
        {
            var employees = _employeeService.GetEmploeesByAVGSalary();
            Console.WriteLine("The number of employees with above-average salaries: " + employees.Count);
            
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        
        private void UpdateEmployeeById()
        {
            
            int? employeeId = _inputService.GetInt("Enter employee ID: ");
            if (!employeeId.HasValue) return;
            
            var employee = _employeeService.GetEmployeeById(employeeId.Value);
            if (employee == null)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            
            string firstName = _inputService.GetStr("Enter first name: ", false);
            string lastName = _inputService.GetStr("Enter last name: ", false);
            string email = _inputService.GetEmail("Enter email: ", false);
            DateOnly? dateOfBirth = _inputService.GetDateOnly("Enter date of birth: ", false);
            decimal? salary = _inputService.GetDecimal("Enter salary: ", false);
            
            _employeeService.UpdateEmployeeById( employeeId.Value,  firstName, lastName, email, dateOfBirth, salary);
            Console.WriteLine("Employee updates successfully.\nPress any key to continue...");
            Console.ReadKey();   
        }

        private void DeleteEmployeeById()
        {
            int? employeeId = _inputService.GetInt("Enter employee ID: ");
            if (!employeeId.HasValue) return;
            
            var employee = _employeeService.GetEmployeeById(employeeId.Value);
            if (employee == null)
            {
                Console.WriteLine($"Employee with ID {employeeId} not found.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            
            _employeeService.DeleteEmployeeById(employeeId.Value);
            
            Console.WriteLine("Employee deleted successfully.\nPress any key to continue...");
            Console.ReadKey(); 
        }
        
        
        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.Clear();
                Console.WriteLine("*** Employee Solution ***");
                Console.WriteLine("1. Add new employee");
                Console.WriteLine("2. View all employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Print employee count by AVG salary");
                Console.WriteLine("6. Exit");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddEmployee(); break;
                    case "2": ViewAllEmployees(); break;
                    case "3": UpdateEmployeeById(); break;
                    case "4": DeleteEmployeeById(); break;
                    case "5": ViewEmployeesAVGSalaryCount(); break;
                    case "6": return;
                }

            }
        }
}