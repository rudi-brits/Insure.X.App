using Insure.X.Resource.Database.Entities.Client;

namespace Insure.X.Client.Interfaces;

public interface IClientRepository
{
    public ClientEntity? GetClientById(int id);
    public List<ClientEntity> GetClients(string? searchTerm);
}
