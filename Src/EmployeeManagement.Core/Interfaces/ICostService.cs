using EmployeeManagement.Core.Model;

namespace EmployeeManagement.Core.Interfaces
{
    public interface ICostService
    {
        public EmployeeCost GetTotalCostsForEmployee(Employee employee);
    }
}