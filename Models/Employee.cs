using System;
using System.Collections.Generic;

namespace WebAPIDBFirstApproach.Models;

public partial class Employee
{
    public int EmpId { get; set; }

    public string? Ename { get; set; }

    public int? DepId { get; set; }

    public string? City { get; set; }
}
