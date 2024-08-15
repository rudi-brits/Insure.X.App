using Insure.X.Domain.Models;
using Insure.X.Domain.Services;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;

namespace Insure.X.Investment.Services;

/// <summary>
/// InvestmentService extends <see cref="BaseService" /> implements <see cref="IInvestmentService" />
/// </summary>
public class InvestmentService : BaseService, IInvestmentService
{
    /// <summary>
    /// IInvestmentRepository field
    /// </summary>
    private readonly IInvestmentRepository _investmentRepository;

    /// <summary>
    /// InvestmentService constructor
    /// </summary>
    /// <param name="investmentRepository"></param>
    public InvestmentService(IInvestmentRepository investmentRepository)
    {
        _investmentRepository = investmentRepository;
    }

    /// <summary>
    /// GetInvestmentForecastsById
    /// </summary>
    /// <param name="id"></param>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public InvestmentForecastResponseDto? GetInvestmentForecastsById(int id, InvestmentGridQueryParamsDto queryParams)
        => _investmentRepository.GetInvestmentForecastsById(id, queryParams);

    /// <summary>
    /// GetInvestmentForecasts
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public PagedResultDto<List<InvestmentForecastResponseDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams)
        => _investmentRepository.GetInvestmentForecasts(queryParams);

    /// <summary>
    /// GetInvestmentForecastsByClientId
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public PagedResultDto<List<InvestmentForecastResponseDto>> GetInvestmentForecastsByClientId(
        InvestmentGridQueryParamsDto queryParams, int id)
        => _investmentRepository.GetInvestmentForecastsByClientId(queryParams, id);
}
