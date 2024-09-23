namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class WorldPayPayment : IPaymentBase
    {
        public WorldPayPayment(string appSetting)
        {
            throw new System.NotImplementedException();
        }

        //required for Auth;
        public string BankID { get; set; }
        public string DomenID { get; set; }

        public string Charge(decimal amount, CreditCart creditCart)
        {
            WorldPayWebService worldPayWebService = new WorldPayWebService();
            string response = worldPayWebService.Charge(amount, creditCart, BankID, DomenID);
            return response;
        }
    }
}