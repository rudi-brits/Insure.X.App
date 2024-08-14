using Insure.X.Domain.Models;
using Insure.X.Investment.Models;

namespace Insure.X.Investment.Interfaces;

/// <summary>
/// IInvestmentService interface
/// </summary>
public interface IInvestmentService
{
    /// <summary>
    /// GetInvestmentForecastsById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    InvestmentForecastDto? GetInvestmentForecastsById(int id);
    /// <summary>
    /// GetInvestmentForecasts
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams);
    /// <summary>
    /// GetInvestmentForecastsByClientId
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecastsByClientId(GridQueryParamsDto queryParams, int id);
}
