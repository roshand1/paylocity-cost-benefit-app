namespace Paylocity.Services.Models
{
    public class BenefitModel
    {
        public BenefitModel()
        {
            Employee = new EmployeeModel();
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public EmployeeModel Employee { get; set; }             

        public double TotalCostOfBenefit { get; set; }
        public double TotalCostOfBenefitPerPayCheck { get; set; }
    }
}
