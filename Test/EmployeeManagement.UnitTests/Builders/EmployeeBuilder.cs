using EmployeeManagement.Core;
using EmployeeManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.UnitTests.Builders
{
    public class EmployeeBuilder
    {
        private Employee obj;

        public EmployeeBuilder()
        {
            obj = new Employee();
        }

        public EmployeeBuilder WithDefaults()
        {
            obj.Email = "email@email.com";
            obj.FirstName = "firstname";
            obj.LastName = "lastname";
            obj.ID = 1;
            obj.Salary = 2000;
            return this;
        }

        public EmployeeBuilder WithDependents(Dependent dependent, int num = 1)
        {
            if (obj.Dependents == null)
            {
                obj.Dependents = new List<Dependent>();
            }

            var dependents = new List<Dependent>();
            for (int i = 0; i < num; i++)
            {
                dependents.Add(dependent);
            }

            obj.Dependents = dependents;
            return this;
        }

        public Employee Build()
        {
            return obj;
        }
    }
}