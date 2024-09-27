using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class OnlineOrderPayment : PaymentMethodBase
    {        
        protected bool _notifyCustomer;
        public OnlineOrderPayment(IPaymentService paymentService, INotificationService notificationService, IUserService userService, IShoppingCartService shoppingCart, bool notifyCustomer)
        : base(paymentService, notificationService, userService, shoppingCart)
        {           
            _notifyCustomer = notifyCustomer;
        }

        public override void ProcessPayment()
        {
            var paymentDetails = _userService.GetPaymentDetails();
            _paymentService.ChargeCard(paymentDetails, _shoppingCart);
            if (_notifyCustomer)
            {                
                _notificationService.NotifyCustomer();
            }
        }
    }
}
