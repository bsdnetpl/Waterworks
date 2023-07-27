namespace Waterworks.DTO
{
    public class CustomersPayment
    {
        public Guid Id { get; set; }
        public double netto { get; set; }
        public double brutto { get; set; }
        public double  Vat { get; set; }
        public DateTime? DateCheck { get; set; }
        public double  CounterCheckValue { get; set; }
        public Guid UserId { get; set; }

    }
}
