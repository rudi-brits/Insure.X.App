using System.ComponentModel.DataAnnotations;

namespace Insure.X.Resource.Database.Entities.Lookups;

/// <summary>
/// InterestTypeEntity class extends <see cref="BaseEntity" />
/// </summary>
public class InterestTypeEntity : BaseEntity
{
    /// <summary>
    /// Description
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;
}
