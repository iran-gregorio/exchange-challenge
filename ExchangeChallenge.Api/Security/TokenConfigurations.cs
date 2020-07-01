using System;

namespace ExchangeChallenge.Api.Security
{
    public class TokenConfigurations
    {
        public string Audience
        {
            get
            {
                return Environment.GetEnvironmentVariable("JWT_AUDIENCE");
            }
        }

        public string Issuer {
            get
            {
                return Environment.GetEnvironmentVariable("JWT_ISSUER");
            }
        }

        public string Secret {
            get
            {
                return Environment.GetEnvironmentVariable("JWT_SECRET");
            }
        }
    }
}
