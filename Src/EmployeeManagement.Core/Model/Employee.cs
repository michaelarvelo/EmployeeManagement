using EmployeeManagement.Core.Model;
using System.Collections.Generic;

namespace EmployeeManagement.Core
{
    public class Employee : Person
    {
        public string Email { get; set; }
        public double Salary { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }
    }
}