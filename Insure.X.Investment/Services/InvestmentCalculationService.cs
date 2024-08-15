using Insure.X.Investment.Enums;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Entities.Investment;

namespace Insure.X.Investment.Services;

/// <summary>
/// InvestmentCalculationService implements <see cref="IInvestmentCalculationService" />
/// </summary>
public class InvestmentCalculationService : IInvestmentCalculationService
{
    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="forecastDate"></param>
    /// <returns></returns>
    public decimal CalculateForecastedAmount(InvestmentEntity entity, DateTime? forecastDate)
        => CalculateForecastedAmount(entity.LumpSum, entity.AnnualInterestRate, entity.InterestTypeId, 
            entity.StartDate, forecastDate);

    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="dto"></param>
    /// <param name="forecastDate"></param>
    /// <returns></returns>
    public decimal CalculateForecastedAmount(InvestmentForecastResponseDto dto, DateTime? forecastDate)
        => CalculateForecastedAmount(dto.LumpSum, dto.AnnualInterestRate, dto.InterestTypeId, 
            dto.StartDate, forecastDate);

    /// <summary>
    /// CalculateForecastedAmount
    /// </summary>
    /// <param name="lumpSum"></param>
    /// <param name="annualInterestRate"></param>
    /// <param name="interestTypeId"></param>
    /// <param name="startDate"></param>
    /// <param name="forecastDate"></param>
    /// <returns></returns>
    public decimal CalculateForecastedAmount(decimal lumpSum, decimal annualInterestRate, int interestTypeId,
        DateTime startDate, DateTime? forecastDate)
    {
        if (forecastDate == null)
            return lumpSum;

        var calculationDate = (DateTime)forecastDate;
        var years           = (calculationDate - startDate).Days / 365.25m;
        var interestRate    = annualInterestRate / 100;

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

    /// <summary>
    /// CompoundInterestAccruedRate
    /// </summary>
    /// <param name="interestRate"></param>
    /// <param name="years"></param>
    /// <param name="compoundingPeriod"></param>
    /// <returns></returns>
    private static decimal CompoundInterestAccruedRate(decimal interestRate, decimal years, decimal compoundingPeriod)
        => (decimal)Math.Pow((double)(1 + interestRate / compoundingPeriod), (double)(years * compoundingPeriod));
}
