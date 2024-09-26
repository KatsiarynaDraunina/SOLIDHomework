using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public abstract class PaymentMethodBase
    {
        protected IPaymentService _paymentService;
        protected INotificationService _notificationService;
        protected IUserService _userService;
        protected IShoppingCartService _shoppingCart;       
       
        protected PaymentMethodBase(IPaymentService paymentService, INotificationService notificationService, IUserService userService, IShoppingCartService shoppingCart)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
            _userService = userService;
            _shoppingCart = shoppingCart;           
        }
       
        public abstract void ProcessPayment();
    }
}
