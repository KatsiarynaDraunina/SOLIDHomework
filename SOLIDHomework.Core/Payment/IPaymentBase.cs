namespace SOLIDHomework.Core.Payment
{
    public interface IPaymentBase
    {

        string Charge(decimal amount, CreditCart creditCart);
    }
}