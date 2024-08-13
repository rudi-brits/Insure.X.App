using Insure.X.Domain.Models;
using Insure.X.Resource.Database.Entities.Client;

namespace Insure.X.Client.Models;

public class ClientDto : PersonDto
{
    public int Id { get; set; }
    public string IdNumber { get; set; } = string.Empty;

    public ClientDto(ClientEntity clientEntity)
    {
        Id        = clientEntity.Id;
        IdNumber  = clientEntity.IdNumber;
        Firstname = clientEntity.Firstname;
        Surname   = clientEntity.Surname;
    }
}
