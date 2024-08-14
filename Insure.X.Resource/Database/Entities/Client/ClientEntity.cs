using System.ComponentModel.DataAnnotations;

namespace Insure.X.Resource.Database.Entities.Client;

/// <summary>
/// ClientEntity class extends <see cref="BaseEntity" />
/// </summary>
public class ClientEntity : BaseEntity
{
    /// <summary>
    /// Firstname
    /// </summary>
    [Required]
    [MaxLength(150)]
    public string Firstname { get; set; } = string.Empty;
    /// <summary>
    /// Surname
    /// </summary>
    [Required]
    [MaxLength(150)]
    public string Surname { get; set; } = string.Empty;
    /// <summary>
    /// IdNumber
    /// </summary>
    [Required]
    [MaxLength(13)]
    public string IdNumber { get; set; } = string.Empty;
}
