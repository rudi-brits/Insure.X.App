using Insure.X.Resource.Database.Entities.Lookups;

namespace Insure.X.Resource.Database.Entities.Investment;

public class InvestmentEntity : BaseEntity
{
    public int ClientId { get; set; }
    public decimal LumpSum { get; set; }
    public DateTime StartDate { get; set; }
    public decimal AnnualInterestRate { get; set; }
    public int InterestTypeId { get; set; }
}
