using EmployeeManagement.Core.Enums;

namespace EmployeeManagement.Core.Model
{
    public class Dependent : Person
    {
        public int EmployeeID { get; set; }
        public Relationship Relationship { get; set; }
    }
}