using EmployeeManagement.Core.Model;

namespace EmployeeManagement.Core.Repositories
{
    public interface IPaycheckRepository
    {
        Paycheck GetPaycheckByEmployeeID(int id);
    }
}