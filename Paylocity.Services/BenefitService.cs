using Paylocity.Services.Interfaces;
using Paylocity.Services.Models;

namespace Paylocity.Services
{
    public class BenefitService: IBenefitService
    {
        private double _benefitPercentage;
        private int _dependentBenefitCost;
        private int _employeeBenefitCost;
        public BenefitService(double benefitPercentage, int dependentBenefitCost, int employeeBenefitCost)
        {
            _benefitPercentage = benefitPercentage;
            _dependentBenefitCost = dependentBenefitCost;   
            _employeeBenefitCost=employeeBenefitCost;
        }
        public BenefitModel CalculateEmployeeBenefit(EmployeeModel employee)
        {
            var benefitModel = new BenefitModel()
            {
                Success = true
            };
            try
            {
                double benefitCost = BenefitCalculation(employee.FirstName, false);
                employee.CostOfBenefit = benefitCost;
                employee.CostOfBenefitPerPayCheck = CalculateBenefitPerPayCheck(benefitCost);
                
                foreach (var item in employee.Dependents)
                {
                    item.CostOfBenefit = BenefitCalculation(item.FirstName, true);
                    item.CostOfBenefitPerPayCheck = CalculateBenefitPerPayCheck(item.CostOfBenefit);
                    benefitCost = benefitCost + item.CostOfBenefit;
                }
                benefitModel.TotalCostOfBenefit = benefitCost;
                benefitModel.TotalCostOfBenefitPerPayCheck = CalculateBenefitPerPayCheck(benefitCost);
                employee.Salary = 2000 - benefitModel.TotalCostOfBenefitPerPayCheck;
                benefitModel.Employee = employee;
                return benefitModel;

            }
            catch (Exception ex)
            {
                benefitModel.Success = false;
                benefitModel.Message = "Something went wrong!!";
                // Log Exception
            }
            return benefitModel;
        }
        private double CalculateBenefitPerPayCheck(double yearlyCostBenefit)
        {
            return Math.Round(yearlyCostBenefit / 26, 2);
        }

        private double BenefitCalculation(string name, bool isDependent)
        {
            int benefitCost = isDependent ? _dependentBenefitCost : _employeeBenefitCost;
            double benefit = 0;
            if (name.ToLower().StartsWith("a"))
            {
                benefit = benefitCost - benefitCost * _benefitPercentage;
            }
            else
            {
                benefit = benefitCost;
            }
            return benefit;
        }
    }
}