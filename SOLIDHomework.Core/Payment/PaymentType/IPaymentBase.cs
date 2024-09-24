namespace SOLIDHomework.Core.Payment.PaymentType
{
    public interface IPaymentBase
    {
        string Charge(decimal amount, CreditCart creditCart);
    }
}