namespace Waterworks.DTO
{
    public class CustomersPaymentDTO
    {
        public double netto { get; set; }
        public double brutto { get; set; }
        public double Vat { get; set; }
        public double CounterCheckValue { get; set; }
        public bool isPayed { set; get; } = false;
    }
}
