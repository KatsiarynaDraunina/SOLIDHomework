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
        public PaymentMethodBase GetPaymentMethod(IShoppingCartService shoppingCart, bool notifyCustomer)
        {
            var paymentDetails = _userService.GetPaymentDetails();
            switch (paymentDetails.PaymentMethod)
            {
                case Enums.PaymentMethod.CreditCard:
                    return new CreditCardPayment(_paymentService, _notificationService, _userService, shoppingCart);                  

                case Enums.PaymentMethod.OnlineOrder:
                    return new OnlineOrderPayment(_paymentService, _notificationService, _userService, shoppingCart, notifyCustomer);
                   
                default:
                    throw new NotSupportedException($"Payment method {paymentDetails.PaymentMethod} is not supported.");
            }
        }
    }
}
