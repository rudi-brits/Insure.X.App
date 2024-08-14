using Insure.X.Client.Models;
using Insure.X.Domain.Models;

namespace Insure.X.Client.Interfaces;

/// <summary>
/// IClientRepository interface
/// </summary>
public interface IClientRepository
{
    /// <summary>
    /// GetClientById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ClientDto? GetClientById(int id);
    /// <summary>
    /// GetClients
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public PagedResultDto<List<ClientDto>> GetClients(GridQueryParamsDto queryParams);
}
