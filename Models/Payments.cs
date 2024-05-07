namespace WebApplication1.Models
{
    public class Payment
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int CreditCard { get; set; }
        public DateTime ExpMonth { get; set; }
        public DateTime ExpYear { get; set; }
        public int CVV { get; set; }


        public Payment() { }
    }
}
