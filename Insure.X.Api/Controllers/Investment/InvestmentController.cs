using Insure.X.Api.Controllers.Base;
using Insure.X.Investment.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Insure.X.Api.Controllers.Investment;

public class InvestmentController : InsureXController
{
    private readonly IInvestmentService _investmentService;

    public InvestmentController(IInvestmentService investmentService)
    {
        _investmentService = investmentService;
    }

    [HttpGet("{Id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetInvestmentForecastsByClientId(int Id)
    {
        var investmentForecasts = _investmentService.GetInvestmentForecastsByClientId(Id);
        return Ok(investmentForecasts);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetInvestmentForecasts([FromQuery] string? searchTerm)
    {
        var investmentForecasts = _investmentService.GetInvestmentForecasts(searchTerm);
        return Ok(investmentForecasts);
    }
}
