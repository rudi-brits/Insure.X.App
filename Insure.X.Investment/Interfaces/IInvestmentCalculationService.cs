using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Entities.Investment;

namespace Insure.X.Investment.Interfaces;

public interface IInvestmentCalculationService
{
    decimal CalculateForecastedAmount(InvestmentEntity entity);
    decimal CalculateForecastedAmount(InvestmentForecastDto dto);
    decimal CalculateForecastedAmount(decimal lumpSum, DateTime startDate, decimal annualInterestRate, int interestTypeId);
}
