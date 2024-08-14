using Insure.X.Domain.Models;
using Insure.X.Resource.Database.Entities.Client;

namespace Insure.X.Client.Models;

/// <summary>
/// ClientDto extends <see cref="PersonDto" />
/// </summary>
public class ClientDto : PersonDto
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// IdNumber
    /// </summary>
    public string IdNumber { get; set; } = string.Empty;

    /// <summary>
    /// ClientDto constructor
    /// </summary>
    /// <param name="clientEntity"></param>
    public ClientDto(ClientEntity clientEntity)
    {
        Id        = clientEntity.Id;
        IdNumber  = clientEntity.IdNumber;
        Firstname = clientEntity.Firstname;
        Surname   = clientEntity.Surname;
    }
}
