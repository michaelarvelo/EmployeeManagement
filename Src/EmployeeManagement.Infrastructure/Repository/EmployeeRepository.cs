using EmployeeManagement.Core;
using EmployeeManagement.Core.Model;
using EmployeeManagement.Core.Repositories;
using EmployeeManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ManagementContext context;
        private readonly ILogger<EmployeeRepository> logger;

        public EmployeeRepository(ManagementContext context, ILogger<EmployeeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void AddEntity(object model)
        {
            try
            {
                context.Add(model);
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem adding that employee: {ex.Message}");
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                var employee = context.Employees.Include(d => d.Dependents).First(x => x.ID == id);
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem deleting that employee: {ex.Message}");
            }
        }

        public bool EmployeeExists(int id)
        {
            return context.Employees.Any(e => e.ID == id);
        }

        public IEnumerable<Person> GetDependentsByEmployeeID(int id)
        {
            return GetEmployeeByID(id)?.Dependents;
        }

        public Employee GetEmployeeByID(int id)
        {
            try
            {
                return context.Employees.Include(d => d.Dependents).First(e => e.ID == id);
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem finding that employee: {ex.Message}");
                return null;
            }
        }

        public EmployeeCost GetEmployeeCost(int employeeID)
        {
            try
            {
                var benefitPolicy = context.BenefitPolicies.First(x => x.IsActive);
                var costService = new CostService(benefitPolicy);
                return costService.GetTotalCostsForEmployee(context.Employees.Include(d => d.Dependents).FirstOrDefault(x => x.ID == employeeID));
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem calculating employee cost: {ex.Message}");
                return null;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return context.Employees;
            }
            catch (System.Exception ex)
            {
                logger.LogError($"There was a problem getting the employees: {ex.Message}");
                return null;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            context.Update(employee);
            context.SaveChanges();
        }
    }
}