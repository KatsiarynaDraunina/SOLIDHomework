﻿using SOLIDHomework.Core.Enums;
using System.Collections.Generic;
using System.Linq;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    // Add interfaces for factories
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
            var handler = _listOfHandlers.First(h => h.isApplicable(paymentServiceType));
            
            return handler;
        }        
    }
}