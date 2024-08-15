using Insure.X.Api.Controllers.Base;
using Insure.X.Client.Interfaces;
using Insure.X.Client.Models;
using Insure.X.Domain.Interfaces;
using Insure.X.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Client;

/// <summary>
/// ClientsController extends <see cref="InsureXController" />
/// </summary>
public class ClientsController : InsureXController
{
    /// <summary>
    /// IClientService field
    /// </summary>
    private readonly IClientService _clientService;

    /// <summary>
    /// ClientsController constructor
    /// </summary>
    /// <param name="clientService"></param>
    /// <param name="logService"></param>
    public ClientsController(IClientService clientService,
        ILogService logService) : base(logService)
    {
        _clientService = clientService;
    }

    /// <summary>
    /// GetClientById operation
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(ClientDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetClientById(int id)
    {
        try
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }
        catch (Exception exc)
        {
            LogToConsole(nameof(ClientsController), exc.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// GetClients
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedResultDto<List<ClientDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetClients([FromQuery] GridQueryParamsDto queryParams)
    {
        try
        {
            var pagedResult = _clientService.GetClients(queryParams);
            return Ok(pagedResult);
        }
        catch (Exception exc)
        {
            LogToConsole(nameof(ClientsController), exc.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
