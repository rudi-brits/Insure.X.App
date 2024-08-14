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
    /// <returns></returns>
    public InvestmentForecastDto? GetInvestmentForecastsById(int id)
        => _investmentRepository.GetInvestmentForecastsById(id);

    /// <summary>
    /// GetInvestmentForecasts
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams)
        => _investmentRepository.GetInvestmentForecasts(queryParams);

    /// <summary>
    /// GetInvestmentForecastsByClientId
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecastsByClientId(GridQueryParamsDto queryParams, int id)
        => _investmentRepository.GetInvestmentForecastsByClientId(queryParams, id);
}
