using Insure.X.Domain.Models;
using Insure.X.Domain.Services;
using Insure.X.Investment.Enums;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;

namespace Insure.X.Investment.Services;

public class InvestmentService : BaseService, IInvestmentService
{
    private readonly IInvestmentRepository _investmentRepository;

    public InvestmentService(IInvestmentRepository investmentRepository)
    {
        _investmentRepository = investmentRepository;
    }

    public InvestmentForecastDto? GetInvestmentForecastsById(int id)
        => _investmentRepository.GetInvestmentForecastsById(id);

    public PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams)
        => _investmentRepository.GetInvestmentForecasts(queryParams);

    public PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecastsByClientId(GridQueryParamsDto queryParams, int id)
        => _investmentRepository.GetInvestmentForecastsByClientId(queryParams, id);
}
