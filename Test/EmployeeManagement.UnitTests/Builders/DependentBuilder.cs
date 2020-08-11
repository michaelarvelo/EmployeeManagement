using EmployeeManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.UnitTests.Builders
{
    public class DependentBuilder
    {
        private Dependent obj;

        public DependentBuilder()
        {
            obj = new Dependent();
        }

        public DependentBuilder WithDefaults()
        {
            obj.FirstName = "firstname";
            obj.LastName = "lastname";
            obj.Relationship = Core.Enums.Relationship.Daughter;
            return this;
        }

        public DependentBuilder WithDiscount()
        {
            obj.FirstName = "anything";
            obj.LastName = "lastname";
            obj.Relationship = Core.Enums.Relationship.Son;
            return this;
        }

        public Dependent Build()
        {
            return obj;
        }
    }
}