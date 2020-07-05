﻿namespace ExchangeChallenge.Api.Exceptions
{
    public class HttpResponseException
    {
        public int Status { get; set; } = 500;
        public object Value { get; set; }
    }
}
