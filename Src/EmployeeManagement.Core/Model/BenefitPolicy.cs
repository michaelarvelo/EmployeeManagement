namespace EmployeeManagement.Core.Model
{
    public class BenefitPolicy
    {
        public int ID { get; set; }
        public double EmployeeCostPerYear { get; set; }
        public double DependentCostPerYear { get; set; }
        public char LetterToDiscount { get; set; }
        public double DiscountAmount { get; set; }
        public bool IsActive { get; set; }
        public int ChecksPerYear { get; set; }
    }
}