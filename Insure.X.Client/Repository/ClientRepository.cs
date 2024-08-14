using Insure.X.Client.Interfaces;
using Insure.X.Client.Models;
using Insure.X.Domain.Extensions;
using Insure.X.Domain.Models;
using Insure.X.Domain.Repository;
using Insure.X.Resource.Database.Data;
using Insure.X.Resource.Database.Entities.Client;
using System.Linq.Dynamic.Core;

namespace Insure.X.Client.Repository;

/// <summary>
/// ClientRepository extends <see cref="BaseRepository" />, implements <see cref="IClientRepository" />
/// </summary>
public class ClientRepository : BaseRepository, IClientRepository
{
    /// <summary>
    /// ClientRepository constructor
    /// </summary>
    /// <param name="insureXDatabase"></param>
    public ClientRepository(InsureXDatabase insureXDatabase) 
        : base(insureXDatabase)
    {
        SetFilterFields(new[]
        {
            nameof(ClientEntity.Firstname),
            nameof(ClientEntity.Surname),
            nameof(ClientEntity.IdNumber)
        });
    }

    /// <summary>
    /// GetClientById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ClientDto? GetClientById(int id)
        => _insureXDatabase.Clients
            .Select(client => new ClientDto(client))
            .FirstOrDefault(client => client.Id == id);

    /// <summary>
    /// GetClients
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    public PagedResultDto<List<ClientDto>> GetClients(GridQueryParamsDto queryParams)
    {
        var filteredQuery = _insureXDatabase.Clients
            .FilterByParams(queryParams.Filter, _filterFields!);

        var totalRecords = filteredQuery.Count();
        var data = filteredQuery
            .OrderByParams(queryParams.SortField, queryParams.SortOrder)
            .PageByParams(queryParams.PageNumber, queryParams.PageSize)
            .Select(client => new ClientDto(client))
            .ToList();

        return new(data ?? new(), totalRecords);
    } 
}
