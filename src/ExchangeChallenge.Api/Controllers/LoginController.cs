using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExchangeChallenge.Infra.Configurations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ExchangeChallenge.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly TokenConfigurations _tokenConfigurations;

        public LoginController(TokenConfigurations tokenConfigurations) =>
            _tokenConfigurations = tokenConfigurations;

        [HttpGet]
        public ActionResult GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("user_id", "1"));
            permClaims.Add(new Claim("category", "VAREJO"));

            IdentityModelEventSource.ShowPII = true;
   
            var token = new JwtSecurityToken(_tokenConfigurations.Issuer,  
                            _tokenConfigurations.Audience,  
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
           
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt_token);
        }
    }
}
