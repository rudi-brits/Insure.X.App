using Insure.X.Domain.Extensions;
using Insure.X.Domain.Models;
using Insure.X.Domain.Repository;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;
using Insure.X.Resource.Database.Data;

namespace Insure.X.Investment.Repository;

/// <summary>
/// InvestmentRepository interface extends <see cref=BaseRepository" /> implements <see cref="IInvestmentRepository" />
/// </summary>
public class InvestmentRepository : BaseRepository, IInvestmentRepository
{
    /// <summary>
    /// IInvestmentCalculationService field
    /// </summary>
    private readonly IInvestmentCalculationService _investmentCalculationService;

    /// <summary>
    /// InvestmentRepository constructor
    /// </summary>
    /// <param name="insureXDatabase"></param>
    /// <param name="investmentCalculationService"></param>
    public InvestmentRepository(InsureXDatabase insureXDatabase,
        IInvestmentCalculationService investmentCalculationService)
        : base(insureXDatabase)
    {
        _investmentCalculationService = investmentCalculationService;

        SetFilterFields(new[]
        {
            nameof(InvestmentForecastDto.Firstname),
            nameof(InvestmentForecastDto.Surname)
        });
    }

    /// <summary>
    /// GetInvestmentForecastsById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public InvestmentForecastDto? GetInvestmentForecastsById(int id)
    {
        var baseQueryable = GetInvestmentForecastQueryable(true);
        return baseQueryable
            .FirstOrDefault(forecast => forecast.Id == id);
    }

    /// <summary>
    /// GetInvestmentForecasts
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecasts(GridQueryParamsDto queryParams)
        => GetPagedInvestmentForecastQueryable(queryParams);

    /// <summary>
    /// GetInvestmentForecastsByClientId
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public PagedResultDto<List<InvestmentForecastDto>> GetInvestmentForecastsByClientId(GridQueryParamsDto queryParams, int id)
        => GetPagedInvestmentForecastQueryable(queryParams, clientId: id);

    /// <summary>
    /// GetPagedInvestmentForecastQueryable
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="clientId"></param>
    /// <returns></returns>
    private PagedResultDto<List<InvestmentForecastDto>> GetPagedInvestmentForecastQueryable(
        GridQueryParamsDto queryParams, int? clientId = null)
    {
        var baseQueryable = GetInvestmentForecastQueryable(clientId != null);

        if (clientId != null)
            baseQueryable = baseQueryable
                .Where(forecast => forecast.ClientId == clientId);

        var filteredQuery = baseQueryable
            .FilterByParams(queryParams.Filter, _filterFields!);

        var totalRecords = filteredQuery.Count();
        var data = filteredQuery
            .OrderByParams(queryParams.SortField, queryParams.SortOrder)
            .PageByParams(queryParams.PageNumber, queryParams.PageSize)
            .ToList();

        return new(data ?? new(), totalRecords);
    }

    /// <summary>
    /// GetInvestmentForecastQueryable
    /// </summary>
    /// <param name="includeForecastedAmount"></param>
    /// <returns></returns>
    private IQueryable<InvestmentForecastDto> GetInvestmentForecastQueryable(bool includeForecastedAmount)
    {
        var baseQueryable =
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
                InterestType       = interestType.Description,
                ForecastedAmount =
                    includeForecastedAmount
                        ? _investmentCalculationService.CalculateForecastedAmount(investment)
                        : 0
            };

        return baseQueryable;
    }
}