using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class CreditCardPayment : PaymentMethodBase
    {
        public CreditCardPayment(IPaymentService paymentService, INotificationService notificationService, PaymentDetails paymentDetails, IShoppingCartService shoppingCart)
        : base(paymentService, notificationService, paymentDetails, shoppingCart) { }

        public override void ProcessPayment()
        {
            _paymentService.ChargeCard(_paymentDetails, _shoppingCart);
        }
    }
}
