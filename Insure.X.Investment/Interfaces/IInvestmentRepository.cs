using Insure.X.Domain.Models;
using Insure.X.Investment.Models;

namespace Insure.X.Investment.Interfaces;

public interface IInvestmentRepository
{
    InvestmentForecastDto? GetInvestmentForecastsById(int id);
    PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams);
    PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecastsByClientId(GridQueryParamsDto queryParams, int clientId);
}
