using Insure.X.Client.Models;
using Insure.X.Domain.Models;

namespace Insure.X.Client.Interfaces;

/// <summary>
/// IClientService interface
/// </summary>
public interface IClientService
{
    /// <summary>
    /// GetClientById
    /// </summary>
    /// <param name="id"></param>
    /// <returns>The <see cref="ClientDto" /> nullable result</returns>
    public ClientDto? GetClientById(int id);
    /// <summary>
    /// GetClients
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns>The paged result</returns>
    public PagedResultDto<List<ClientDto>> GetClients(GridQueryParamsDto queryParams);
}
