namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class WorldPayWebService: IWorldPayWebService
    {
        public string Charge(decimal amount, CreditCart creditCart, string bankID, string domenID)
        {
            return "Success";
        }
    }
}