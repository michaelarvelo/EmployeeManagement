using EmployeeManagement.Infrastructure;
using EmployeeManagement.UnitTests.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EmployeeManagement.UnitTests
{
    public class EmployeeCostTest
    {
        [Fact]
        public void CheckTotalCostPerYearWithEmployeeWithoutDiscountAndDependentWithDiscount()
        {
            //Arrange
            var employee = new EmployeeBuilder()
                .WithDefaults()
                .WithDependents(new DependentBuilder().WithDiscount().Build())
                .Build();

            var costService = new CostService(new BenefitPolicyBuilder().WithDefaults().Build());

            //Act
            var result = costService.GetTotalCostsForEmployee(employee);

            //Assert
            Assert.True(result.TotalCostPerYear == 1500);
        }
    }
}