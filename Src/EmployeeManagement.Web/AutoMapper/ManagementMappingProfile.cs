using AutoMapper;
using EmployeeManagement.Core;
using EmployeeManagement.Core.Model;
using EmployeeManagement.Web.ViewModels;

namespace EmployeeManagement.Web.AutoMapper
{
    public class ManagementMappingProfile : Profile
    {
        public ManagementMappingProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ReverseMap();
            CreateMap<BenefitPolicy, BenefitPolicyViewModel>()
                .ReverseMap();
            CreateMap<Dependent, DependentViewModel>()
                .ReverseMap();
        }
    }
}