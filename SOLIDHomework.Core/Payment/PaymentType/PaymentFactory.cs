using SOLIDHomework.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    // Add interfaces for factories
    public class PaymentFactory: IPaymentFactory
    {
        private List<IPaymentHandler> _listOfHandlers = new List<IPaymentHandler>();

        public void RegisterHandler(IPaymentHandler handler)
        {
            if (!_listOfHandlers.Contains(handler))
            {
                _listOfHandlers.Add(handler);
            }
        }

        public IPaymentHandler GetPaymentHandler(PaymentServiceType paymentServiceType) //decimal amount, CreditCart creditCart,
        {           
            var handler = _listOfHandlers.First(h => h.isApplicable(paymentServiceType));
            
            return handler;
        }
        //private readonly IPayPalWebService _payPalWebService;
        //private readonly IWorldPayWebService _worldPayWebService;

        //public PaymentFactory(IPayPalWebService payPalWebService, IWorldPayWebService worldPayWebService)
        //{
        //    _payPalWebService = payPalWebService;
        //    _worldPayWebService = worldPayWebService;
        //}

        //public IPaymentHandler GetPaymentService(PaymentServiceType serviceType)
        //{
        //    // Let's move from swtiches to handlers
        //    switch (serviceType)
        //    {
        //        case PaymentServiceType.PayPal:
        //            return new PayPalPayment(ConfigurationManager.AppSettings["accountName"],
        //                ConfigurationManager.AppSettings["password"], _payPalWebService);
        //        case PaymentServiceType.WorldPay:
        //            return new WorldPayPaymentHandler(ConfigurationManager.AppSettings["BankID"], _worldPayWebService);
        //        default:
        //            throw new NotImplementedException("No such service.");
        //    }
        //}
    }
}