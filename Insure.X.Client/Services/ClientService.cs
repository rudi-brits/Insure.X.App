using Insure.X.Client.Interfaces;
using Insure.X.Client.MappingProfiles;
using Insure.X.Client.Models;
using Insure.X.Domain.Services;

namespace Insure.X.Client.Services;

public class ClientService : BaseService, IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
        SetupMapper<ClientMappingProfile>();
    }

    public ClientDto? GetClientById(int id)
    {
        var clientEntity = _clientRepository.GetClientById(id);
        return clientEntity == null
            ? null
            : _mapper!.Map<ClientDto>(clientEntity);
    }

    public List<ClientDto> GetClients(string? searchTerm)
    {
        var clientEntities = _clientRepository.GetClients(searchTerm) ?? new();
        return _mapper!.Map<List<ClientDto>>(clientEntities);
    }
}
