using Paylocity.DAL.Entity;

namespace Paylocity.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<bool> AddEmployeeAsync(EmployeeEntity employee);
    }
}
