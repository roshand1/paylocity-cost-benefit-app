namespace PaylocityWebApp.Models
{
    public class BenefitDto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public EmployeeDto Employee { get; set; }
        public double CostOfBenefit { get; set; }
        public double CostOfBenefitPerPayCheck { get; set; }
    }
}
