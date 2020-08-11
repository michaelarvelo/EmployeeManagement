using EmployeeManagement.Core;
using EmployeeManagement.Core.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.ViewModels
{
    public class DependentViewModel : PersonViewModelBase
    {
        public Relationship Relationship { get; set; }
        public List<DependentViewModel> CurrentDependents { get; set; }
        public EmployeeViewModel EmployeeVM { get; set; }
        public int EmployeeID { get; set; }

        public DependentViewModel() => CurrentDependents = new List<DependentViewModel>();
    }
}