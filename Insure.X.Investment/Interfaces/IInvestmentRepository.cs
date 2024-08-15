using Insure.X.Domain.Models;
using Insure.X.Investment.Models;

namespace Insure.X.Investment.Interfaces;

/// <summary>
/// IInvestmentRepository interface
/// </summary>
public interface IInvestmentRepository
{
    /// <summary>
    /// GetInvestmentForecastsById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    InvestmentForecastResponseDto? GetInvestmentForecastsById(int id, InvestmentGridQueryParamsDto queryParams);
    /// <summary>
    /// GetInvestmentForecasts
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    PagedResultDto<List<InvestmentForecastResponseDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams);
    /// <summary>
    /// GetInvestmentForecastsByClientId
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    PagedResultDto<List<InvestmentForecastResponseDto>> GetInvestmentForecastsByClientId(InvestmentGridQueryParamsDto queryParams, int id);
}