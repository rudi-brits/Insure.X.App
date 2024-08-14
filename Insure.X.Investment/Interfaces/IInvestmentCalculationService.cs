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
    /// <returns></returns>
    decimal CalculateForecastedAmount(InvestmentEntity entity);
    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    decimal CalculateForecastedAmount(InvestmentForecastDto dto);
    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="lumpSum"></param>
    /// <param name="startDate"></param>
    /// <param name="annualInterestRate"></param>
    /// <param name="interestTypeId"></param>
    /// <returns></returns>
    decimal CalculateForecastedAmount(decimal lumpSum, DateTime startDate, decimal annualInterestRate, int interestTypeId);
}
