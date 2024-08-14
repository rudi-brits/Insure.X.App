using Insure.X.Domain.Models;
using Insure.X.Domain.Serialization;
using System.Text.Json.Serialization;

namespace Insure.X.Investment.Models;

/// <summary>
/// InvestmentForecastDto class extends <see cref="PersonDto" /> 
/// </summary>
public class InvestmentForecastDto : PersonDto
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// ClientId
    /// </summary>
    public int ClientId { get; set; }
    /// <summary>
    /// LumpSum
    /// </summary>
    public decimal LumpSum { get; set; }
    /// <summary>
    /// StartDate
    /// </summary>
    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime StartDate { get; set; }
    /// <summary>
    /// AnnualInterestRate
    /// </summary>
    public decimal AnnualInterestRate { get; set; }
    /// <summary>
    /// ForecastedAmount
    /// </summary>
    public decimal ForecastedAmount { get; set; }
    /// <summary>
    /// InterestTypeId
    /// </summary>
    [JsonIgnore]
    public int InterestTypeId { get; set; }
    /// <summary>
    /// InterestType
    /// </summary>
    public string InterestType { get; set; } = string.Empty;
}
