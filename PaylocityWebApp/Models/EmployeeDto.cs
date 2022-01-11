namespace PaylocityWebApp.Models
{
    public class EmployeeDto
    {
        public EmployeeDto()
        {
            Dependents = new List<DependentDto>();
        }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<DependentDto> Dependents { get; set; }
    }
}
