using Insure.X.Client.Interfaces;
using Insure.X.Client.Models;
using Insure.X.Domain.Models;
using Insure.X.Domain.Services;

namespace Insure.X.Client.Services;

public class ClientService : BaseService, IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public ClientDto? GetClientById(int id)
        => _clientRepository.GetClientById(id);

    public PagedResultDto<List<ClientDto>> GetClients(GridQueryParamsDto queryParams)
        => _clientRepository.GetClients(queryParams);
}
