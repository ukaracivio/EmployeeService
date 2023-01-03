using System;
using System.Collections.Generic;

namespace EmployeeService.Models
{
    public partial class Emp
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public int? Age { get; set; }
        public int? Salary { get; set; }
    }
}
