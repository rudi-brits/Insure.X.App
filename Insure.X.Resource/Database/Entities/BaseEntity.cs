using System.ComponentModel.DataAnnotations;

namespace Insure.X.Resource.Database.Entities;

/// <summary>
/// BaseEntity
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int Id { get; set; }
}
