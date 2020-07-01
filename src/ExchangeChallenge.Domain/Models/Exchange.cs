namespace ExchangeChallenge.Domain.Models
{
    public class Exchange
    {
        public decimal ValueRequested { get; set; }
        public decimal FactorApplied { get; set; }
        public decimal TaxApplied { get; set; }
        public decimal Total { get; set; }
    }
}
