namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class PayPalPayment : IPaymentBase
    {
        //required for Auth;
        public string AccountName { get; set; }
        public string Password { get; set; }

        private readonly IPayPalWebService _payPalWebService;
        public PayPalPayment(string appSettings, string password, IPayPalWebService payPalWebService)
        {
            _payPalWebService = payPalWebService;
        }

        public string Charge(decimal amount, CreditCart creditCart)
        {           
            string token = _payPalWebService.GetTransactionToken(AccountName, Password);
            string response = _payPalWebService.Charge(amount, token, creditCart);
            return response;
        }
    }
}