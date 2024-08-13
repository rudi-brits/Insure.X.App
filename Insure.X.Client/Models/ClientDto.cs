using Insure.X.Domain.Models;

namespace Insure.X.Client.Models;

public class ClientDto : PersonDto
{
    public int Id { get; set; }
    public string IdNumber { get; set; } = string.Empty;
}
