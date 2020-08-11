using EmployeeManagement.Core;
using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Core.Model;
using System;

namespace EmployeeManagement.Infrastructure.Factories
{
    public abstract class BaseCostFactory
    {
        private readonly BenefitPolicy currentBenefits;

        public BaseCostFactory(BenefitPolicy currentBenefits)
        {
            this.currentBenefits = currentBenefits;
        }

        public BenefitPolicy GetCurrentBenefits()
        {
            return currentBenefits;
        }

        public void CalculateCostForPerson(IBaseCost costForPerson, double costPerYear, Person person)
        {
            if (person.FirstName[0].Equals(currentBenefits.LetterToDiscount))
            {
                costForPerson.CostPerYear = Convert.ToInt32(costPerYear - (costPerYear * currentBenefits.DiscountAmount));
                costForPerson.IsDiscountApplied = true;
            }
            else
            {
                costForPerson.CostPerYear = Convert.ToInt32(costPerYear);
            }
            costForPerson.CostPerCheck = (costForPerson.CostPerYear) / currentBenefits.ChecksPerYear;
        }
    }
}