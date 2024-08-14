using Insure.X.Api.Controllers.Base;
using Insure.X.Client.Interfaces;
using Insure.X.Client.Models;
using Insure.X.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Client;

public class ClientsController : InsureXController
{
    private readonly IClientService _clientService;

    public ClientsController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetClientById(int id)
    {
        var client = _clientService.GetClientById(id);
        if (client == null)
            return NotFound();

        return Ok(client);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PagedResultDto<List<ClientDto>>), StatusCodes.Status200OK)]
    public IActionResult GetClients([FromQuery] GridQueryParamsDto queryParams)
    {        
        var pagedResult = _clientService.GetClients(queryParams);
        return Ok(pagedResult);
    }
}
