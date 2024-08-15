using Insure.X.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Base;

/// <summary>
/// InsureXController extends <see cref="ControllerBase" />
/// </summary>
[Route("api/v1/[controller]")]
[ApiController]
public abstract class InsureXController : ControllerBase
{
    /// <summary>
    /// ILogService
    /// </summary>
    protected readonly ILogService _logService;

    /// <summary>
    /// InsureXController constructor
    /// </summary>
    /// <param name="logService"></param>
    protected InsureXController(ILogService logService)
    {
        _logService = logService;
    }

    /// <summary>
    /// LogToConsole
    /// </summary>
    /// <param name="description"></param>
    /// <param name="message"></param>
    protected void LogToConsole(string description, string message)
        => _logService.LogToConsole(description, message);
}
