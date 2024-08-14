using Insure.X.Investment.Enums;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Entities.Investment;

namespace Insure.X.Investment.Services
{
    public class InvestmentCalculationService : IInvestmentCalculationService
    {
        public decimal CalculateForecastedAmount(InvestmentEntity entity)
            => CalculateForecastedAmount(entity.LumpSum, entity.StartDate, entity.AnnualInterestRate, entity.InterestTypeId);

        public decimal CalculateForecastedAmount(InvestmentForecastDto dto)
            => CalculateForecastedAmount(dto.LumpSum, dto.StartDate, dto.AnnualInterestRate, dto.InterestTypeId);

        public decimal CalculateForecastedAmount(decimal lumpSum, DateTime startDate, decimal annualInterestRate, int interestTypeId)
        {
            DateTime financialYearEndDate = DateTime.Now.AddDays(1);

            var years        = (financialYearEndDate - startDate).Days / 365.25m;
            var interestRate = annualInterestRate / 100;

            return (InterestTypeEnum)interestTypeId switch
            {
                InterestTypeEnum.Simple
                    => lumpSum + (lumpSum * interestRate * years),
                InterestTypeEnum.CompoundedMonthly
                    => lumpSum * CompoundInterestAccruedRate(interestRate, years, 12),
                InterestTypeEnum.CompoundedAnnually
                    => lumpSum * CompoundInterestAccruedRate(interestRate, years, 1),

                _ => lumpSum
            };
        }       

        private static decimal CompoundInterestAccruedRate(decimal interestRate, decimal years, decimal compoundingPeriod)
            => (decimal)Math.Pow((double)(1 + interestRate / compoundingPeriod), (double)(years * compoundingPeriod));
    }
}
