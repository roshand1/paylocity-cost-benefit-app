using Paylocity.DAL.Context;
using Paylocity.DAL.Entity;
using Paylocity.DAL.Interfaces;

namespace Paylocity.DAL
{
    public class EmployeeRepository: IEmployeeRepository
    {
        private PaylocityContext _paylocityContext;
        public EmployeeRepository(PaylocityContext paylocityContext)
        {
            _paylocityContext = paylocityContext;
        }
        public async Task<bool> AddEmployeeAsync(EmployeeEntity employee)
        {
            var output = true;
            try
            {
                var employeeContext = new EmployeeContext()
                {
                    Dependent = employee.Dependent,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    EmployeeId = employee.EmployeeId
                };
                await _paylocityContext.Employee.AddAsync(employeeContext);
                await _paylocityContext.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                output = false;
                // Log exception
            }
            return output;
        }
    }
}
