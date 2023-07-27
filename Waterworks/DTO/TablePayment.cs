namespace Waterworks.DTO
{
    public class TablePayment
    {
        public Guid Id { get; set; }
        public string TariffNname { get; set; }
        public string Group { get; set;}
        public string VatTaxSubscription { get; set;}
        public string VatTaxWater { get; set; }
        public string VatTaxSewage { get; set; }
        public double RateWaterNetto { get; set;}
        public double RateSewageNetto { get; set; }
        public double SubscriptionNetto { get; set;}
        public double AddPromotion { get; set;}
        public DateTime DateCreate { get; set; } = DateTime.Now;

    }
}
