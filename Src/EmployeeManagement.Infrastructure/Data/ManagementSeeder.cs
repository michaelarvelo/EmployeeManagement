using EmployeeManagement.Core.Model;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;

namespace EmployeeManagement.Infrastructure.Data
{
    public class ManagementSeeder
    {
        private readonly ManagementContext context;

        public ManagementSeeder(ManagementContext context)
        {
            this.context = context;
        }

        public void Seed()
        {
            context.Database.EnsureCreated();

            if (!context.BenefitPolicies.Any())
            {
                //Need to create benefit rules
                var currentBenefitDeductions = new BenefitPolicy
                {
                    DependentCostPerYear = 500,
                    DiscountAmount = 0.10,
                    ID = 1,
                    LetterToDiscount = 'A',
                    IsActive = true,
                    EmployeeCostPerYear = 1000
                };
                context.BenefitPolicies.AddRange(currentBenefitDeductions);
                context.SaveChanges();
            }
        }
    }
}