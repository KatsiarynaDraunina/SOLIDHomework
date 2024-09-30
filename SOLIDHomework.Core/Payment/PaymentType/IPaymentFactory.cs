using SOLIDHomework.Core.Enums;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    public interface IPaymentFactory
    {
        void RegisterHandler(IPaymentHandler handler);
        IPaymentHandler GetPaymentHandler(PaymentServiceType paymentServiceType);
    }
}