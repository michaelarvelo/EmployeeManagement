using EmployeeManagement.Core;
using EmployeeManagement.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EmployeeManagement.Infrastructure.Data
{
    public class ManagementContext : DbContext
    {
        public ManagementContext(DbContextOptions<ManagementContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<BenefitPolicy> BenefitPolicies { get; set; }
        public DbSet<Paycheck> Paychecks { get; set; }
        public DbSet<Dependent> Dependents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasData(new Employee()
                {
                    ID = 1,
                    FirstName = "Johnny",
                    LastName = "Donuts",
                    Salary = 2000
                });

            modelBuilder.Entity<BenefitPolicy>()
                .HasData(new BenefitPolicy()
                {
                    ID = 1,
                    EmployeeCostPerYear = 1000,
                    DependentCostPerYear = 500,
                    DiscountAmount = 0.10,
                    LetterToDiscount = 'A'
                });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}