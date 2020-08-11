using EmployeeManagement.Core;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Model;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Infrastructure.Factories;

namespace EmployeeManagement.Infrastructure
{
    public class CostService : ICostService
    {
        private readonly DependentCostFactory dependentCostFactory;
        private readonly EmployeeCostFactory employeeCostFactory;

        public CostService(BenefitPolicy benefitPolicy)
        {
            dependentCostFactory = new DependentCostFactory(benefitPolicy);
            employeeCostFactory = new EmployeeCostFactory(benefitPolicy);
        }

        public EmployeeCost GetTotalCostsForEmployee(Employee employee)
        {
            if (employee == null) { return null; }

            return CalculateCosts(employeeCostFactory.GetCostForPerson(employee) as EmployeeCost);

            EmployeeCost CalculateCosts(EmployeeCost employeeInfo)
            {
                foreach (var dependent in employeeInfo.Employee.Dependents)
                {
                    employeeInfo.DependentCosts.Add(dependentCostFactory.GetCostForPerson(dependent) as DependentCost);
                }

                return employeeInfo;
            }
        }
    }
}