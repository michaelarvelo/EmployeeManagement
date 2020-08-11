using EmployeeManagement.Core.Model;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class BenefitsRepository : IBenefitsRepository
    {
        private readonly ManagementContext context;
        private readonly ILogger<BenefitsRepository> logger;

        public BenefitsRepository(ManagementContext context, ILogger<BenefitsRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public BenefitPolicy GetCompanyBenefitsInformation()
        {
            try
            {
                return context.BenefitPolicies.First(x => x.IsActive);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem finding the company benefits: {ex.Message}");
                return null;
            }
        }

        public void UpdateCompanyBenefits(BenefitPolicy benefitPolicy)
        {
            try
            {
                context.Update(benefitPolicy);
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem with the company benefits: {ex.Message}");
            }
        }
    }
}