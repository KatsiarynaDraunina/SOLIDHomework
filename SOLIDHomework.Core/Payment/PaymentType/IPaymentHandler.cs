using SOLIDHomework.Core.Enums;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    public interface IPaymentHandler
    {
        string Charge(decimal amount, CreditCart creditCart);
        bool isApplicable(PaymentServiceType paymentServiceType);
       // void Charge(Account account);
    }
}