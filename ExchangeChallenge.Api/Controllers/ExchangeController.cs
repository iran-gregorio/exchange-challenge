using System.Threading.Tasks;
using ExchangeChallenge.Api.Responses;
using ExchangeChallenge.Api.Security;
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
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService) =>
            _exchangeService = exchangeService;

        [HttpGet]
        [Produces("application/json")]
        [Route("{currency}")]
        public async Task<ActionResult<ExchangeResponse>> Get(string currency, [FromQuery] decimal qty)
        {
            var category = User.GetCategory();
            var exchange = await _exchangeService.GetQuote(category, currency, qty);
            return new ExchangeResponse
            {
                ValueRequested = exchange.ValueRequested,
                FactorApplied = exchange.FactorApplied,
                TaxApplied = exchange.TaxApplied,
                Total = exchange.Total
            };
        }
    }
}
