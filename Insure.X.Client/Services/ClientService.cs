using Insure.X.Client.Interfaces;
using Insure.X.Client.Models;
using Insure.X.Domain.Models;
using Insure.X.Domain.Services;

namespace Insure.X.Client.Services;

/// <summary>
/// ClientService extends <see cref="BaseService" />, implements <see cref="IClientService" />
/// </summary>
public class ClientService : BaseService, IClientService
{
    /// <summary>
    /// IClientRepository field
    /// </summary>
    private readonly IClientRepository _clientRepository;

    /// <summary>
    /// ClientService constructor
    /// </summary>
    /// <param name="clientRepository"></param>
    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    /// <summary>
    /// GetClientById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ClientDto? GetClientById(int id)
        => _clientRepository.GetClientById(id);

    /// <summary>
    /// GetClients
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public PagedResultDto<List<ClientDto>> GetClients(GridQueryParamsDto queryParams)
        => _clientRepository.GetClients(queryParams);
}
