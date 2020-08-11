using EmployeeManagement.Core.Interfaces;

namespace EmployeeManagement.Core.Model
{
    public class DependentCost : IBaseCost
    {
        public DependentCost(Dependent dependent)
        {
            Dependent = dependent;
        }

        public Dependent Dependent { get; set; }
        public bool IsDiscountApplied { get; set; }
        public int CostPerCheck { get; set; }
        public int CostPerYear { get; set; }
    }
}