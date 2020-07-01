using System;
using System.Collections.Generic;

namespace ExchangeChallenge.Data.Factor.Models
{
    public class ExchangeRatesResult
    {
        public DateTime Date { get; set; }
        public string Base { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}
