using Insure.X.Domain.Services;
using Insure.X.Investment.Enums;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Entities.Lookups;

namespace Insure.X.Investment.Services;

public class InvestmentService : BaseService, IInvestmentService
{
    private readonly IInvestmentRepository _investmentRepository;

    public InvestmentService(IInvestmentRepository investmentRepository)
    {
        _investmentRepository = investmentRepository;
    }

    public List<InvestmentForecastDto> GetInvestmentForecastsByClientId(int clientId)
        => GetInvestmentForecasts(() => _investmentRepository.GetInvestmentForecastsByClientId(clientId) ?? new());

    public List<InvestmentForecastDto> GetInvestmentForecasts(string? searchTerm)
        => GetInvestmentForecasts(() => _investmentRepository.GetInvestmentForecasts(searchTerm));

    private List<InvestmentForecastDto> GetInvestmentForecasts(Func<List<InvestmentForecastDto>> getInvestmentForecasts)
    {
        var investmentForecasts = getInvestmentForecasts();
        if (investmentForecasts?.Any() != true)
            return new();

        foreach(var forecast in investmentForecasts)
            forecast.ForecastedAmount = CalculateForecastedAmount(forecast);

        return investmentForecasts;
    }

    public decimal CalculateForecastedAmount(InvestmentForecastDto investment)
    {
        DateTime financialYearEndDate = DateTime.Now.AddDays(1);

        var years        = (financialYearEndDate - investment.StartDate).Days / 365.25m;
        var interestRate = investment.AnnualInterestRate / 100;

        return (InterestTypeEnum)investment.InterestTypeId switch
        {
            InterestTypeEnum.Simple
                => investment.LumpSum + (investment.LumpSum * interestRate * years),
            InterestTypeEnum.CompoundedMonthly
                => investment.LumpSum * CompoundInterestAccruedRate(interestRate, years, 12),
            InterestTypeEnum.CompoundedAnnually
                => investment.LumpSum * CompoundInterestAccruedRate(interestRate, years, 1),

            _ => investment.LumpSum
        };
    }

    private decimal CompoundInterestAccruedRate(decimal interestRate, decimal years, decimal compoundingPeriod)
        => (decimal)Math.Pow((double)(1 + interestRate / compoundingPeriod), (double)(years * compoundingPeriod));
}
