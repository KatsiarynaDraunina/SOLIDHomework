using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;
using System;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    // Add interfaces
    public class PaymentMethodFactory
    {
        private readonly INotificationService _notificationService;
        private readonly IPaymentService _paymentService;

        public PaymentMethodFactory(IPaymentService paymentService, INotificationService notificationService)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
        }

        // Consider returning payment method
        public void GetPaymentMethod(PaymentDetails paymentDetails, IShoppingCartService shoppingCart, string username, bool notifyCustomer)
        {
            switch (paymentDetails.PaymentMethod)
            {
                case Enums.PaymentMethod.CreditCard:
                    new CreditCardPayment(_paymentService, _notificationService, paymentDetails, shoppingCart).ProcessPayment();
                    break;

                case Enums.PaymentMethod.OnlineOrder:
                    new OnlineOrderPayment(_paymentService, _notificationService, paymentDetails, shoppingCart, username, notifyCustomer).ProcessPayment();
                    break;

                default:
                    throw new NotSupportedException($"Payment method {paymentDetails.PaymentMethod} is not supported.");
            }
        }
    }
}
