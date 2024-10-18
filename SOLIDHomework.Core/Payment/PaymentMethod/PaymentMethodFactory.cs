using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    // Add interfaces
    public class PaymentMethodFactory: IPaymentMethodFactory
    {
        private List<IPaymentMethodHandler> _listOfPaymentMethods = new List<IPaymentMethodHandler>();       
        private readonly IUserService _userService;

        public PaymentMethodFactory(IUserService userService)
        {            
            _userService = userService;
        }

        public void RegisterHandler(IPaymentMethodHandler handler)
        {
            if (!_listOfPaymentMethods.Contains(handler))
            {
                _listOfPaymentMethods.Add(handler);
            }
        }

        public IPaymentMethodHandler GetPaymentHandler()
        {
            var paymentDetails = _userService.GetRegisteredUser().PaymentDetails;
            var handler = _listOfPaymentMethods.FirstOrDefault(h => h.isApplicable(paymentDetails.PaymentMethod));

            if (handler == null)
            {
                throw new InvalidOperationException($"No payment method handler found for payment method: {paymentDetails.PaymentMethod}");
            }

            return handler;
        }       
    }
}
