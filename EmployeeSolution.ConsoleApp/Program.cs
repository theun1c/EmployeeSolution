using System;
using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Services;
using EmployeeSolution.ConsoleApp.UI;

namespace EmployeeSolution.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new EmployeeDbContext(); 
            var employeeService = new EmployeeService(context);
            var inputService = new InputService();
            var consoleMenu = new ConsoleMenu(employeeService, inputService);
            consoleMenu.Menu();
        }
    }
}