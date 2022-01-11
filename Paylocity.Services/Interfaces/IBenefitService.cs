using Paylocity.Services.Models;

namespace Paylocity.Services.Interfaces
{
    public interface IBenefitService
    {
        BenefitModel CalculateEmployeeBenefit(EmployeeModel employee);
    }
}
