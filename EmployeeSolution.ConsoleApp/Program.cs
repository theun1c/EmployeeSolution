using System;
using System.ComponentModel;
using System.Threading.Channels;
using EmployeeSolution.ConsoleApp.Models;
using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Services;

namespace EmployeeSolution.ConsoleApp
{
    internal class Program
    {
        private static EmployeeService _employeeService;
        private static void InitService()
        {
            var context = new EmployeeDbContext();
            _employeeService = new EmployeeService(context);
        }

        private static void AddEmployee()
        {
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter date of birth: ");
            DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine("Enter salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            
            _employeeService.CreateEmployee(firstName, lastName, email, dateOfBirth, salary);

            Console.WriteLine("Employee added successfully.\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void ViewAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            foreach (var e in employees)
            {
                Console.WriteLine(e.EmployeeId + " " + e.FirstName + " " + e.LastName + " " + e.Email + " " + e.DateOfBirth + " " + e.Salary);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void UpdateEmployeeById()
        {
            Console.WriteLine("Enter employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter date of birth: ");
            
            DateOnly dateOfBirth = DateOnly.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter salary: ");
            decimal salary = decimal.Parse(Console.ReadLine());
            
            _employeeService.UpdateEmployeeById( employeeId,  firstName, lastName, email, dateOfBirth, salary);
            Console.WriteLine("Employee updates successfully.\nPress any key to continue...");
            Console.ReadKey();   
        }

        private static void DeleteEmployeeById()
        {
            Console.WriteLine("Enter employee ID: ");
            int employeeId = int.Parse(Console.ReadLine());
            
            _employeeService.DeleteEmployeeById(employeeId);
            
            Console.WriteLine("Employee deleted successfully.\nPress any key to continue...");
            Console.ReadKey(); 
        }
        
        
        private static void Menu()
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
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddEmployee(); break;
                    case "2": ViewAllEmployees(); break;
                    case "3": UpdateEmployeeById(); break;
                    case "4": DeleteEmployeeById(); break;
                    case "5": return;
                }

            }
        }
        
        static void Main(string[] args)
        {
            InitService();
            Menu();
        }
    }
}