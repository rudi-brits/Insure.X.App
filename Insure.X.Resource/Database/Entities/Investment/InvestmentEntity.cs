namespace Insure.X.Resource.Database.Entities.Investment;

/// <summary>
/// InvestmentEntity class extends <see cref="BaseEntity" />
/// </summary>
public class InvestmentEntity : BaseEntity
{
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
    public DateTime StartDate { get; set; }
    /// <summary>
    /// AnnualInterestRate
    /// </summary>
    public decimal AnnualInterestRate { get; set; }
    /// <summary>
    /// InterestTypeId
    /// </summary>
    public int InterestTypeId { get; set; }
}
