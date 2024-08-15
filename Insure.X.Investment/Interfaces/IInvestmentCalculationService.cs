using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Entities.Investment;

namespace Insure.X.Investment.Interfaces;

/// <summary>
/// IInvestmentCalculationService interface
/// </summary>
public interface IInvestmentCalculationService
{
    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="forecastDate"></param>
    /// <returns></returns>
    decimal CalculateForecastedAmount(InvestmentEntity entity, DateTime? forecastDate);
    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="forecastDate"></param>
    /// <returns></returns>
    decimal CalculateForecastedAmount(InvestmentForecastResponseDto dto, DateTime? forecastDate);
    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="lumpSum"></param>
    /// <param name="annualInterestRate"></param>
    /// <param name="interestTypeId"></param>
    /// <param name="startDate"></param>
    /// <param name="forecastDate"></param>
    /// <returns></returns>
    decimal CalculateForecastedAmount(decimal lumpSum, decimal annualInterestRate, int interestTypeId, 
        DateTime startDate, DateTime? forecastDate);
}
