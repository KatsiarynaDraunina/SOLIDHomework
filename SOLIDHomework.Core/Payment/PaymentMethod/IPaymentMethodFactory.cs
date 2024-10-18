namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public interface IPaymentMethodFactory
    {
        void RegisterHandler(IPaymentMethodHandler handler);
        IPaymentMethodHandler GetPaymentHandler();        
    }
}