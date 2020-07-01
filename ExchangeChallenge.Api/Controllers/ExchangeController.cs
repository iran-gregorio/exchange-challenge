using System;
using ExchangeChallenge.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeChallenge.Api.Controllers
{
    [ApiController]
    [Route("exchange")]
    [Authorize("Bearer")]
    public class ExchangeController : ControllerBase
    {
        private IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService) =>
            _exchangeService = exchangeService;

        [HttpGet]
        public ActionResult<String> Get()
        {
            return _exchangeService.GetQuote();
        }
    }
}
