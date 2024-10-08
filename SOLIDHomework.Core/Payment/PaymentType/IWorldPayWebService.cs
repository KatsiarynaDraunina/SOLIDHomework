namespace SOLIDHomework.Core.Payment.PaymentType
{
    public interface IWorldPayWebService
    {
        string Charge(decimal amount, CreditCart creditCart, string bankID, string domenID);
    }
}