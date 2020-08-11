using EmployeeManagement.Core.Model;
using EmployeeManagement.Core.Repositories;
using System;

namespace EmployeeManagement.Infrastructure.Repository
{
    public class PaycheckRepository : IPaycheckRepository
    {
        public Paycheck GetPaycheckByEmployeeID(int id)
        {
            throw new NotImplementedException();
        }
    }
}