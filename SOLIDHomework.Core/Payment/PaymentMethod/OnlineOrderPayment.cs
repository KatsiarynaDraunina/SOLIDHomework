using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class OnlineOrderPayment : PaymentMethodBase
    {
        protected string _username;
        protected bool _notifyCustomer;
        public OnlineOrderPayment(IPaymentService paymentService, INotificationService notificationService, PaymentDetails paymentDetails, IShoppingCartService shoppingCart, string username, bool notifyCustomer)
        : base(paymentService, notificationService, paymentDetails, shoppingCart)
        {
            _username = username;
            _notifyCustomer = notifyCustomer;
        }

        public override void ProcessPayment()
        {
            _paymentService.ChargeCard(_paymentDetails, _shoppingCart);
            if (_notifyCustomer)
            {
                _notificationService.NotifyCustomer(_username);
            }
        }
    }
}
