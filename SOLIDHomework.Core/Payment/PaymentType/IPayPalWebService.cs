namespace SOLIDHomework.Core.Payment.PaymentType
{
    public interface IPayPalWebService
    {
        string GetTransactionToken(string accountName, string password);
        string Charge(decimal amount, string token, CreditCart creditCard);
    }
}
