using EmployeeManagement.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Core.Model
{
    public class EmployeeCost : IBaseCost
    {
        public EmployeeCost(Employee employee)
        {
            Employee = employee;
            DependentCosts = new List<DependentCost>();
        }

        public Employee Employee { get; set; }
        public List<DependentCost> DependentCosts { get; set; }
        public bool IsDiscountApplied { get; set; }
        public int CostPerCheck { get; set; }
        public int CostPerYear { get; set; }
        public int TotalCostPerPaycheck => GetTotalCostPerPaycheck();
        public int TotalCostPerYear => GetTotalCostPerYear();

        private int GetTotalCostPerPaycheck()
        {
            return DependentCosts.Sum(item => item.CostPerCheck) + CostPerCheck;
        }

        private int GetTotalCostPerYear()
        {
            return DependentCosts.Sum(item => item.CostPerYear) + CostPerYear;
        }
    }
}