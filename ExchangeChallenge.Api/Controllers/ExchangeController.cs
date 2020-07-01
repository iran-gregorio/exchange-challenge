using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeChallenge.Api.Controllers
{
    [ApiController]
    [Route("exchange")]
    [Authorize("Bearer")]
    public class ExchangeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<String> Get()
        {
            return "Ok";
        }
    }
}
