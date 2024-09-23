using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public abstract class PaymentMethodBase
    {
        protected IPaymentService _paymentService;
        protected INotificationService _notificationService;
        protected PaymentDetails _paymentDetails;
        protected IShoppingCartService _shoppingCart;       
       
        protected PaymentMethodBase(IPaymentService paymentService, INotificationService notificationService, PaymentDetails paymentDetails, IShoppingCartService shoppingCart)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
            _paymentDetails = paymentDetails;
            _shoppingCart = shoppingCart;           
        }
       
        public abstract void ProcessPayment();
    }
}
