namespace EmployeeManagement.Core.Interfaces
{
    public interface IBaseCost
    {
        bool IsDiscountApplied { get; set; }
        int CostPerCheck { get; set; }
        int CostPerYear { get; set; }
    }
}