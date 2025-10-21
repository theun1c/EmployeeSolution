using System;
using EmployeeSolution.ConsoleApp.Models;
using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Services;

namespace EmployeeSolution.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var context = new EmployeeDbContext();
            EmployeeService employeeService = new EmployeeService(context);


            Console.WriteLine(employeeService.CreateEmployee("Vova", "Vovkin", "vov@gmail.com",  new DateOnly(2008, 4, 29) , 123456));

            
        }
    }
}