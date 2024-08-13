using System.ComponentModel.DataAnnotations;

namespace Insure.X.Resource.Database.Entities.Lookups;

public class InterestTypeEntity : BaseEntity
{
    [Required]
    public string Description { get; set; } = string.Empty;
}
