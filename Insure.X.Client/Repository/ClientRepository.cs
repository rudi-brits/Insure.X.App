using Insure.X.Client.Interfaces;
using Insure.X.Domain.Extensions;
using Insure.X.Domain.Repository;
using Insure.X.Resource.Database.Data;
using Insure.X.Resource.Database.Entities.Client;

namespace Insure.X.Client.Repository;

public class ClientRepository : BaseRepository, IClientRepository
{
    public ClientRepository(InsureXDatabase insureXDatabase) 
        : base(insureXDatabase)
    {
    }

    public ClientEntity? GetClientById(int id)
        => _insureXDatabase.Clients.FirstOrDefault(client => client.Id == id);

    public List<ClientEntity> GetClients(string? searchTerm)
        => _insureXDatabase.Clients
            .SearchByTermContainsOrElse(searchTerm,
                client => client.Firstname,
                client => client.Surname,
                client => client.IdNumber)
            .OrderBy(client => client.Firstname)
            .ToList();
}
