using Microsoft.VisualStudio.TestTools.UnitTesting;
using Paylocity.Services.Models;
using System;
using System.Collections.Generic;

namespace Paylocity.Services.Tests
{
    [TestClass]
    public class BenefitService_Tests
    {
        [TestMethod]
        public void CalculateEmployeeBenefit_WithDiscount()
        {
            var discountPercentage = 0.1;
            var employeeCostBenefit = 1000;
            var dependentCostBenefit = 500;

            
            var testSubject = new BenefitService(discountPercentage, dependentCostBenefit, employeeCostBenefit);
            var employeeModel = new EmployeeModel()
            {
                FirstName = "Amber",
                LastName = "Alert",
                Dependents = new List<DependentModel>()
                {
                    new DependentModel()
                    {
                        FirstName = "Amberica",
                        LastName = "AlertTest",
                        Type = "Spouse"
                    }
                }
            };

            var expectedTotalCostBenefit = (employeeCostBenefit - employeeCostBenefit * discountPercentage) + (dependentCostBenefit - dependentCostBenefit * discountPercentage);
            var expectedPerPaycheckCostBenefit = Math.Round(expectedTotalCostBenefit / 26,2);
            var result = testSubject.CalculateEmployeeBenefit(employeeModel);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalCostOfBenefit, expectedTotalCostBenefit);
            Assert.AreEqual(result.TotalCostOfBenefitPerPayCheck, expectedPerPaycheckCostBenefit);
        }


        [TestMethod]
        public void CalculateEmployeeBenefit_WithPartialDiscount()
        {
            var discountPercentage = 0.1;
            var employeeCostBenefit = 1000;
            var dependentCostBenefit = 500;


            var testSubject = new BenefitService(discountPercentage, dependentCostBenefit, employeeCostBenefit);
            var employeeModel = new EmployeeModel()
            {
                FirstName = "Aamber",
                LastName = "Alert",
                Dependents = new List<DependentModel>()
                {
                    new DependentModel()
                    {
                        FirstName = "Bamber",
                        LastName = "AlertTest",
                        Type = "Spouse"
                    }
                }
            };

            var expectedTotalCostBenefit = (employeeCostBenefit - employeeCostBenefit * discountPercentage) + dependentCostBenefit;
            var expectedPerPaycheckCostBenefit = Math.Round(expectedTotalCostBenefit / 26, 2);
            var result = testSubject.CalculateEmployeeBenefit(employeeModel);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalCostOfBenefit, expectedTotalCostBenefit);
            Assert.AreEqual(result.TotalCostOfBenefitPerPayCheck, expectedPerPaycheckCostBenefit);
        }

        [TestMethod]
        public void CalculateEmployeeBenefit_WithoutDiscount()
        {
            var discountPercentage = 0.1;
            var employeeCostBenefit = 1000;
            var dependentCostBenefit = 500;


            var testSubject = new BenefitService(discountPercentage, dependentCostBenefit, employeeCostBenefit);
            var employeeModel = new EmployeeModel()
            {
                FirstName = "Bamber",
                LastName = "Alert",
                Dependents = new List<DependentModel>()
                {
                    new DependentModel()
                    {
                        FirstName = "Bamber",
                        LastName = "AlertTest",
                        Type = "Spouse"
                    }
                }
            };

            var expectedTotalCostBenefit = employeeCostBenefit + dependentCostBenefit;
            var expectedPerPaycheckCostBenefit = Math.Round(((double) expectedTotalCostBenefit / 26),2);
            var result = testSubject.CalculateEmployeeBenefit(employeeModel);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.TotalCostOfBenefit, expectedTotalCostBenefit);
            Assert.AreEqual(result.TotalCostOfBenefitPerPayCheck, expectedPerPaycheckCostBenefit);
        }
    }
}