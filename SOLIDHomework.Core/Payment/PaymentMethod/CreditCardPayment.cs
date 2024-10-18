namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class CreditCardPayment : IPaymentMethodHandler
    {
        protected IPaymentService _paymentService;       
       
        public CreditCardPayment(IPaymentService paymentService)
        {
            _paymentService = paymentService;           
        }

        public bool isApplicable(Enums.PaymentMethod paymentMethod)
        {
            return paymentMethod == Enums.PaymentMethod.CreditCard;
        }

        public void ProcessPayment()
        {           
            _paymentService.ChargeCard();
        }
    }
}
