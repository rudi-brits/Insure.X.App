﻿using Insure.X.Api.Controllers.Base;
using Insure.X.Domain.Models;
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

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetInvestmentForecastsById(int id)
    {
        var investmentForecast = _investmentService.GetInvestmentForecastsById(id);
        return Ok(investmentForecast);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetInvestmentForecasts([FromQuery] GridQueryParamsDto queryParams)
    {
        var investmentForecasts = _investmentService.GetInvestmentForecasts(queryParams);
        return Ok(investmentForecasts);
    }

    //[HttpGet("{clientId:int}")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //public IActionResult GetInvestmentForecastsByClientId([FromQuery] GridQueryParamsDto queryParams, int clientId)
    //{
    //    var investmentForecasts = _investmentService.GetInvestmentForecastsByClientId(queryParams, clientId);
    //    return Ok(investmentForecasts);
    //}
}
