namespace SOLIDHomework.Core.Model
{
    public class Account
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
    }
}