using EmployeeManagement.Core;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Model;

namespace EmployeeManagement.Infrastructure.Factories
{
    public class EmployeeCostFactory : BaseCostFactory, ICostFactory
    {
        public EmployeeCostFactory(BenefitPolicy currentBenefits) : base(currentBenefits)
        {
        }

        public IBaseCost GetCostForPerson(Person person)
        {
            var employeeCost = new EmployeeCost(person as Employee);
            CalculateCostForPerson(employeeCost, GetCurrentBenefits().EmployeeCostPerYear, person);
            return employeeCost;
        }
    }
}