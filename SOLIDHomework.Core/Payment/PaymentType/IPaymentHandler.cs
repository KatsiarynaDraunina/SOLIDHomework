using SOLIDHomework.Core.Enums;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    public interface IPaymentHandler
    {
        string Charge(decimal amount, CreditCart creditCart);
        bool IsApplicable(PaymentServiceType paymentServiceType);      
    }
}