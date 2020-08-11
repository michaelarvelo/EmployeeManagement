namespace EmployeeManagement.Core.Model
{
    public class Paycheck
    {
        public int ID { get; set; }
        public double BaseSalary { get; set; }
        public double SalaryAfterDeductions { get; set; }
        public Employee Employee { get; set; }
    }
}