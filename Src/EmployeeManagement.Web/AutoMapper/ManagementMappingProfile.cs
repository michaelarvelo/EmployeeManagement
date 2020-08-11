using AutoMapper;
using EmployeeManagement.Core;
using EmployeeManagement.Core.Model;
using EmployeeManagement.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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