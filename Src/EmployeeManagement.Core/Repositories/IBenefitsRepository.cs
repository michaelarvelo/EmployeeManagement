using EmployeeManagement.Core.Model;

namespace EmployeeManagement.Core.Repositories
{
    public interface IBenefitsRepository
    {
        BenefitPolicy GetCompanyBenefitsInformation();
        void UpdateCompanyBenefits(BenefitPolicy benefitPolicy);
    }
}