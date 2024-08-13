using Insure.X.Client.Interfaces;
using Insure.X.Client.Models;
using Insure.X.Domain.Extensions;
using Insure.X.Domain.Models;
using Insure.X.Domain.Repository;
using Insure.X.Resource.Database.Data;
using Insure.X.Resource.Database.Entities.Client;
using System.Linq.Dynamic.Core;

namespace Insure.X.Client.Repository;

public class ClientRepository : BaseRepository, IClientRepository
{
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

    public ClientDto? GetClientById(int id)
        => _insureXDatabase.Clients.
            Select(client => new ClientDto(client)).
            FirstOrDefault(client => client.Id == id);

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

        return new()
        {
            Data = data,
            TotalRecords = totalRecords
        };
    } 
}
