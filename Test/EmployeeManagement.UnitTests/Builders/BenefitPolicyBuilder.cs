using EmployeeManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.UnitTests.Builders
{
    public class BenefitPolicyBuilder
    {
        private BenefitPolicy obj;

        public BenefitPolicyBuilder()
        {
            obj = new BenefitPolicy();
        }

        public BenefitPolicyBuilder WithDefaults()
        {
            obj.EmployeeCostPerYear = 1000;
            obj.DependentCostPerYear = 500;
            obj.LetterToDiscount = 'A';
            obj.DiscountAmount = 0.1;
            obj.IsActive = true;
            obj.ChecksPerYear = 26;

            return this;
        }

        public BenefitPolicy Build()
        {
            return obj;
        }
    }
}