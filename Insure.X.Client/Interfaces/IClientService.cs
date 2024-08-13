﻿using Insure.X.Client.Models;
using Insure.X.Domain.Models;

namespace Insure.X.Client.Interfaces;

public interface IClientService
{
    public ClientDto? GetClientById(int id);
    public PagedResultDto<List<ClientDto>> GetClients(GridQueryParamsDto queryParams);
}
