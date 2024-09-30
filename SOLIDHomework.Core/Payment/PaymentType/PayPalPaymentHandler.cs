using SOLIDHomework.Core.Enums;
using System.Configuration;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class PayPalPaymentHandler : IPaymentHandler
    {
        //required for Auth;
        public string AccountName { get; set; }
        public string Password { get; set; }

        private readonly IPayPalWebService _payPalWebService;
        public PayPalPaymentHandler(IPayPalWebService payPalWebService)
        {
            _payPalWebService = payPalWebService;
        }
        public bool isApplicable(PaymentServiceType paymentServiceType)
        {
            return paymentServiceType == PaymentServiceType.PayPal;
        }

        public string Charge(decimal amount, CreditCart creditCart)
        {           
            string token = _payPalWebService.GetTransactionToken(ConfigurationManager.AppSettings["accountName"], 
                ConfigurationManager.AppSettings["password"]);
            string response = _payPalWebService.Charge(amount, token, creditCart);
            return response;
        }
    }
}