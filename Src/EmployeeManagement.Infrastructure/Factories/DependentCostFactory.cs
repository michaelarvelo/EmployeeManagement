using EmployeeManagement.Core;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Model;

namespace EmployeeManagement.Infrastructure.Factories
{
    public class DependentCostFactory : BaseCostFactory, ICostFactory
    {
        public DependentCostFactory(BenefitPolicy currentBenefits) : base(currentBenefits)
        {
        }

        public IBaseCost GetCostForPerson(Person person)
        {
            var dependentCost = new DependentCost(person as Dependent);
            CalculateCostForPerson(dependentCost, GetCurrentBenefits().DependentCostPerYear, person);
            return dependentCost;
        }
    }
}