using System.Threading.Tasks;
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
        [Produces("application/json)]
        public async Task<ActionResult<string>> Get()
        {
            var userId = User.GetUserId();
            var category = User.GetCategory();
            return await _exchangeService.GetQuote(userId, category);
        }
    }
}
