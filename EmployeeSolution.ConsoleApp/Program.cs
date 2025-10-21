using System;
using EmployeeSolution.ConsoleApp.Models;
using EmployeeSolution.ConsoleApp.Data;
using EmployeeSolution.ConsoleApp.Services;

namespace EmployeeSolution.ConsoleApp
{
    internal class Program
    {
        private static void InitService()
        {
            using var context = new EmployeeDbContext();
            EmployeeService employeeService = new EmployeeService(context);
        }
        
        private static void Menu()
        {
            while (true)
            {
                
            }
        }
        
        static void Main(string[] args)
        {
            InitService();
            Menu();
        }
    }
}