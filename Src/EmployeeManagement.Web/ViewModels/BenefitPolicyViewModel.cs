namespace EmployeeManagement.Web.ViewModels
{
    public class BenefitPolicyViewModel
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