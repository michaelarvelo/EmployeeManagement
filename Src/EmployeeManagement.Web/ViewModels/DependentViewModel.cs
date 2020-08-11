using EmployeeManagement.Core.Enums;
using System.Collections.Generic;

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