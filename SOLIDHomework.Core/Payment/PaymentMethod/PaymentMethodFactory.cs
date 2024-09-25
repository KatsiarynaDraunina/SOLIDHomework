using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;
using System;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    // Add interfaces
    public class PaymentMethodFactory: IPaymentMethodFactory
    {
        private readonly INotificationService _notificationService;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;

        public PaymentMethodFactory(IPaymentService paymentService, INotificationService notificationService, IUserService userService)
        {
            _paymentService = paymentService;
            _notificationService = notificationService;
            _userService = userService;
        }

        // Consider returning payment method
        public PaymentMethodBase GetPaymentMethod(string username, IShoppingCartService shoppingCart, bool notifyCustomer)
        {
            var paymentDetails = _userService.GetByUsername(username).PaymentDetails;
            switch (paymentDetails.PaymentMethod)
            {
                case Enums.PaymentMethod.CreditCard:
                    return new CreditCardPayment(_paymentService, _notificationService, paymentDetails, shoppingCart);                  

                case Enums.PaymentMethod.OnlineOrder:
                    return new OnlineOrderPayment(_paymentService, _notificationService, paymentDetails, shoppingCart, username, notifyCustomer);
                   
                default:
                    throw new NotSupportedException($"Payment method {paymentDetails.PaymentMethod} is not supported.");
            }
        }
    }
}
