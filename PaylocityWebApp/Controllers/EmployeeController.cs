using Microsoft.AspNetCore.Mvc;
using Paylocity.Services;
using Paylocity.Services.Interfaces;
using Paylocity.Services.Models;
using PaylocityWebApp.Factories;
using PaylocityWebApp.Models;

namespace PaylocityWebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBenefitService _employeeService;

        public EmployeeController(ILogger<WeatherForecastController> logger,
            IBenefitService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult CalculateEmployeeBenefit(EmployeeDto employee)
        {   
            var employeeModel = EmployeeRequestDtoFactory.Parse(employee);
            var result = _employeeService.CalculateEmployeeBenefit(employeeModel);
            return Ok(result);
        }
    }
}
