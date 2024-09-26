using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class CreditCardPayment : PaymentMethodBase
    {
        public CreditCardPayment(IPaymentService paymentService, INotificationService notificationService, IUserService userService, IShoppingCartService shoppingCart)
        : base(paymentService, notificationService, userService, shoppingCart) { }

        public override void ProcessPayment()
        {
            var paymentDetails = _userService.GetByUsername(_shoppingCart.Username).PaymentDetails;
            _paymentService.ChargeCard(paymentDetails, _shoppingCart);
        }
    }
}
