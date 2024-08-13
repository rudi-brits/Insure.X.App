using Insure.X.Api.Controllers.Base;
using Insure.X.Client.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Client;

public class ClientController : InsureXController
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetClientById(int id)
    {
        var client = _clientService.GetClientById(id);
        if (client == null)
            return NotFound();

        return Ok(client);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetClients([FromQuery] string? searchTerm)
    {
        var clients = _clientService.GetClients(searchTerm);
        return Ok(clients);
    }
}
