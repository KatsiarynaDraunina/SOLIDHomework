using SOLIDHomework.Core.Enums;
using System;
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
            var handler = _listOfHandlers.FirstOrDefault(h => h.IsApplicable(paymentServiceType));

            if (handler == null)
            {
                throw new InvalidOperationException($"No payment handler found for payment service type: {paymentServiceType}");
            }

            return handler;
        }        
    }
}