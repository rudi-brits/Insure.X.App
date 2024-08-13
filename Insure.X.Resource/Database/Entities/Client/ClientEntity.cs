using System.ComponentModel.DataAnnotations;

namespace Insure.X.Resource.Database.Entities.Client;

public class ClientEntity : BaseEntity
{
    [Required]
    [MaxLength(150)]
    public string Firstname { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Surname { get; set; } = string.Empty;

    [Required]
    [MaxLength(13)]
    public string IdNumber { get; set; } = string.Empty;
}
