using Paylocity.DAL.Entity;
using Paylocity.Services.Models;

namespace Paylocity.Services.Factories
{
    public static class EmployeeModelFactory
    {
        public static EmployeeEntity Parse(EmployeeModel employee)
        {
            return new EmployeeEntity
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName, 
                LastName = employee.LastName,
                Dependent = employee.Dependent
            };
        }
    }
}
