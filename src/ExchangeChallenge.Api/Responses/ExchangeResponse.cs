namespace ExchangeChallenge.Api.Responses
{
    public class ExchangeResponse
    {
        public decimal ValueRequested { get; set; }
        public decimal FactorApplied { get; set; }
        public decimal TaxApplied { get; set; }
        public decimal Total { get; set; }
    }
}