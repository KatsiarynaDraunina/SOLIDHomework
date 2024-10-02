using SOLIDHomework.Core.Services;
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
            var handler = _listOfPaymentMethods.First(h => h.isApplicable(paymentDetails.PaymentMethod));

            return handler;
        }       
    }
}
