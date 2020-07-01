using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExchangeChallenge.Api.Security;
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
        private TokenConfigurations _tokenConfigurations;

        public LoginController(TokenConfigurations tokenConfigurations)
        {
            _tokenConfigurations = tokenConfigurations;
        }

        [HttpGet]
        public ActionResult GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfigurations.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Create a List of Claims, Keep claims name short    
            var permClaims = new List<Claim>();
            permClaims.Add(new Claim("user_id", "1"));
            permClaims.Add(new Claim("categoru", "VAREJO"));

            IdentityModelEventSource.ShowPII = true;

            //Create Security Token object by giving required parameters    
            var token = new JwtSecurityToken(_tokenConfigurations.Issuer, //Issure    
                            _tokenConfigurations.Audience,  //Audience    
                            permClaims,
                            expires: DateTime.Now.AddDays(1),
                            signingCredentials: credentials);
           
            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwt_token);
        }
    }
}
