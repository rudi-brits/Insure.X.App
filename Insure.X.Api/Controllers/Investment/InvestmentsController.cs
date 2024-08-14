using Insure.X.Api.Controllers.Base;
using Insure.X.Domain.Interfaces;
using Insure.X.Domain.Models;
using Insure.X.Investment.Interfaces;
using Insure.X.Investment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Investment;

/// <summary>
/// InvestmentsController extends <see cref="InsureXController" />
/// </summary>
public class InvestmentsController : InsureXController
{
    /// <summary>
    /// IInvestmentService field
    /// </summary>
    private readonly IInvestmentService _investmentService;

    /// <summary>
    /// InvestmentsController constructor
    /// </summary>
    /// <param name="investmentService"></param>
    /// <param name="logService"></param>
    public InvestmentsController(IInvestmentService investmentService,
        ILogService logService) : base(logService)
    {
        _investmentService = investmentService;
    }

    /// <summary>
    /// GetInvestmentForecastsById
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(InvestmentForecastDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetInvestmentForecastsById(int id)
    {
        try
        {
            var investmentForecast = _investmentService.GetInvestmentForecastsById(id);
            if (investmentForecast == null)
                return NotFound();

            return Ok(investmentForecast);
        }
        catch (Exception exc)
        {
            LogToConsole(nameof(InvestmentsController), exc.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// GetInvestmentForecasts
    /// </summary>
    /// <param name="queryParams"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetInvestmentForecasts([FromQuery] GridQueryParamsDto queryParams)
    {
        try
        {
            var investmentForecasts = _investmentService.GetInvestmentForecasts(queryParams);
            return Ok(investmentForecasts);
        }
        catch (Exception exc)
        {
            LogToConsole(nameof(InvestmentsController), exc.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    /// <summary>
    /// GetInvestmentForecastsByClientId
    /// </summary>
    /// <param name="queryParams"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("clients/{id:int}/investments")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetInvestmentForecastsByClientId([FromQuery] GridQueryParamsDto queryParams, int id)
    {
        try
        {
            var investmentForecasts = _investmentService.GetInvestmentForecastsByClientId(queryParams, id);
            return Ok(investmentForecasts);
        }
        catch (Exception exc)
        {
            LogToConsole(nameof(InvestmentsController), exc.Message);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
