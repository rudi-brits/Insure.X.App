using Insure.X.Domain.Extensions;
using Insure.X.Domain.Repository;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Data;

namespace Insure.X.Investment.Repository;

public class InvestmentRepository : BaseRepository, IInvestmentRepository
{
    public InvestmentRepository(InsureXDatabase insureXDatabase)
        : base(insureXDatabase)
    {
        SetFilterFields(new[]
        {
            nameof(InvestmentForecastDto.Firstname),
            nameof(InvestmentForecastDto.Surname)
        });
    }

    public List<InvestmentForecastDto>? GetInvestmentForecastsByClientId(int clientId)
        => GetInvestmentForecastQueryable()
            .OrderByDescending(forecast => forecast.StartDate)
            .Where(forecast => forecast.ClientId == clientId)
            .ToList();

    public List<InvestmentForecastDto> GetInvestmentForecasts(string? searchTerm)
        => GetInvestmentForecastQueryable()
            .FilterByParams(
                searchTerm, _filterFields!)
            .OrderBy(forecast => forecast.Firstname)
            .ThenByDescending(forecast => forecast.StartDate)
            .ToList();

    private IQueryable<InvestmentForecastDto> GetInvestmentForecastQueryable()
    {
        var investmentForecastQueryable = 
            from
               investment in _insureXDatabase.Investments
            join
              client in _insureXDatabase.Clients
            on
              investment.ClientId equals client.Id
            join
              interestType in _insureXDatabase.InterestTypes
            on
              investment.InterestTypeId equals interestType.Id
            select new InvestmentForecastDto
            {
                Id                 = investment.Id,
                ClientId           = client.Id,
                Firstname          = client.Firstname,
                Surname            = client.Surname,
                LumpSum            = investment.LumpSum,
                StartDate          = investment.StartDate,
                AnnualInterestRate = investment.AnnualInterestRate,
                InterestTypeId     = investment.InterestTypeId,
                InterestType       = interestType.Description
            };

        return investmentForecastQueryable;
    }
}