using SOLIDHomework.Core.Enums;
using System;
using System.Configuration;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    // Add interfaces for factories
    public class PaymentFactory
    {
        private readonly IPayPalWebService _payPalWebService;
        private readonly IWorldPayWebService _worldPayWebService;

        public PaymentFactory(IPayPalWebService payPalWebService, IWorldPayWebService worldPayWebService)
        {
            _payPalWebService = payPalWebService;
            _worldPayWebService = worldPayWebService;
        }

        public IPaymentBase GetPaymentService(PaymentServiceType serviceType)
        {
            // Let's move from swtiches to handlers
            switch (serviceType)
            {
                case PaymentServiceType.PayPal:
                    return new PayPalPayment(ConfigurationManager.AppSettings["accountName"],
                        ConfigurationManager.AppSettings["password"], _payPalWebService);
                case PaymentServiceType.WorldPay:
                    return new WorldPayPayment(ConfigurationManager.AppSettings["BankID"], _worldPayWebService);
                default:
                    throw new NotImplementedException("No such service.");
            }
        }
    }
}