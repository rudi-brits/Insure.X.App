namespace Insure.X.Domain.Models;

/// <summary>
/// InvestmentQueryParamsDto class extends <see cref="BaseService" />
/// </summary> 
public class InvestmentGridQueryParamsDto : GridQueryParamsDto
{
    /// <summary>
    /// ForecastDate
    /// </summary>
    public DateTime? ForecastDate { get; set; }
}
