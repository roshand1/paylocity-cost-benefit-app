namespace Paylocity.Services.Models
{
    public class EmployeeModel
    {
        public EmployeeModel()
        {
            Dependents = new List<DependentModel>();
        }
        public string EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Dependent { get; set; }
        public double Salary { get; set; }
        public double CostOfBenefit { get; set; }
        public double CostOfBenefitPerPayCheck { get; set; }
        public List<DependentModel> Dependents { get; set; }

    }
}
