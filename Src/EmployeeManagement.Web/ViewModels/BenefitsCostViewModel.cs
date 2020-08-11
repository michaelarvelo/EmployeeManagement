namespace EmployeeManagement.Web.ViewModels
{
    public class BenefitsCostViewModel
    {
        public EmployeeViewModel Employee { get; set; }
        public double AmountSaved { get; set; }
        public double TotalCostsPerPaycheck { get; set; }
    }
}