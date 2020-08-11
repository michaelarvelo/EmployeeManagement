using EmployeeManagement.Core.Model;
using System.Collections.Generic;

namespace EmployeeManagement.Core.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeByID(int id);

        IEnumerable<Person> GetDependentsByEmployeeID(int id);

        IEnumerable<Employee> GetEmployees();

        void AddEntity(object model);

        void UpdateEmployee(Employee employee);

        bool EmployeeExists(int id);

        void DeleteEmployee(int id);

        EmployeeCost GetEmployeeCost(int employeeID);
    }
}