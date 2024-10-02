using SOLIDHomework.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class PaymentFactory: IPaymentFactory
    {
        private List<IPaymentHandler> _listOfHandlers = new List<IPaymentHandler>();

        public void RegisterHandler(IPaymentHandler handler)
        {
            if (!_listOfHandlers.Contains(handler))
            {
                _listOfHandlers.Add(handler);
            }
        }

        public IPaymentHandler GetPaymentHandler(PaymentServiceType paymentServiceType)
        { 
            // Add an exception handling, in case there are not applicable handlers
            var handler = _listOfHandlers.First(h => h.IsApplicable(paymentServiceType));
            
            return handler;
        }        
    }
}