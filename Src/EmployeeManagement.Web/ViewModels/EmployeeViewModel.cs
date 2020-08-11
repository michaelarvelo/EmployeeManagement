using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Web.ViewModels
{
    public class EmployeeViewModel : PersonViewModelBase
    {
        [EmailAddress]
        public string Email { get; set; }

        public double Salary { get; set; }
        public List<DependentViewModel> Dependents { get; set; }
        public DependentViewModel DependentToAdd { get; set; }

        public EmployeeViewModel()
        {
            Dependents = new List<DependentViewModel>();
            DependentToAdd = new DependentViewModel();
        }
    }
}