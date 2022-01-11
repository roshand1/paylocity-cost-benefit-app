using Paylocity.Services.Models;
using PaylocityWebApp.Models;

namespace PaylocityWebApp.Factories
{
    public static class EmployeeRequestDtoFactory
    {
        public static EmployeeModel Parse(EmployeeDto employeeDto)
        {
            var employeeModel = new EmployeeModel()
            {
                EmployeeId = employeeDto.EmployeeId,
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Dependent = employeeDto.Dependents.Count()            
            };
            foreach (var item in employeeDto.Dependents)
            {
                employeeModel.Dependents.Add(new DependentModel
                {
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Type = item.Type
                });
            }
            return employeeModel;
        }
    }
}
