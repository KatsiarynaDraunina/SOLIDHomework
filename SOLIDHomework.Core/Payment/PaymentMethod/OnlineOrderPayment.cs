namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class OnlineOrderPayment : IPaymentMethodHandler
    {        
        protected IPaymentService _paymentService;      
       
        public OnlineOrderPayment(IPaymentService paymentService)       
        {
            _paymentService = paymentService;           
        }

        public bool isApplicable(Enums.PaymentMethod paymentMethod)
        {
            return paymentMethod == Enums.PaymentMethod.OnlineOrder;
        }

        public void ProcessPayment()
        {           
            _paymentService.ChargeCard();           
        }
    }
}
