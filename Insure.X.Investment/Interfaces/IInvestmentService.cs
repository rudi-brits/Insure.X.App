using Insure.X.Investment.Models;

namespace Insure.X.Investment.Interfaces;

public interface IInvestmentService
{
    List<InvestmentForecastDto> GetInvestmentForecastsByClientId(int clientId);
    List<InvestmentForecastDto> GetInvestmentForecasts(string? searchTerm);
}
