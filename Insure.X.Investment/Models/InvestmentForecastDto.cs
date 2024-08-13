using Insure.X.Domain.Models;
using Insure.X.Domain.Serialization;
using System.Text.Json.Serialization;

namespace Insure.X.Investment.Models;

public class InvestmentForecastDto : PersonDto
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public decimal LumpSum { get; set; }

    [JsonConverter(typeof(DateTimeJsonConverter))]
    public DateTime StartDate { get; set; }

    public decimal AnnualInterestRate { get; set; }
    public decimal ForecastedAmount { get; set; }

    [JsonIgnore]
    public int InterestTypeId { get; set; }
    public string InterestType { get; set; } = string.Empty;
}
