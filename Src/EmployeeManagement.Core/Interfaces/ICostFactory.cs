namespace EmployeeManagement.Core.Interfaces
{
    public interface ICostFactory
    {
        IBaseCost GetCostForPerson(Person person);
    }
}