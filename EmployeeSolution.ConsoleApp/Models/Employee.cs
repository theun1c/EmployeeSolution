using System;
using System.Collections.Generic;

namespace EmployeeSolution.ConsoleApp.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public decimal Salary { get; set; }
}
