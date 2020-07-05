using System.Linq;
using System.Security.Claims;

namespace ExchangeChallenge.Api.Security
{
    public static class UserExtension
    {
        public static string GetUserId(this ClaimsPrincipal claimsPrincipal)        
            => claimsPrincipal.Claims.FirstOrDefault(x => x.Type.Equals("user_id"))?.Value;

        public static string GetCategory(this ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal.Claims.FirstOrDefault(x => x.Type.Equals("category"))?.Value;
    }
}
