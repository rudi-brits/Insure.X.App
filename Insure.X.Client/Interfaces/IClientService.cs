using Insure.X.Client.Models;

namespace Insure.X.Client.Interfaces;

public interface IClientService
{
    public ClientDto? GetClientById(int id);
    public List<ClientDto> GetClients(string? searchTerm);
}
