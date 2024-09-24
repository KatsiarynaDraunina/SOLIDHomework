namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class WorldPayPayment : IPaymentBase
    {
        //required for Auth;
        public string BankID { get; set; }
        public string DomenID { get; set; }

        private readonly IWorldPayWebService _worldPayWebService;
        public WorldPayPayment(string appSettings, IWorldPayWebService worldPayWebService)
        {
            _worldPayWebService = worldPayWebService;
        }

        public string Charge(decimal amount, CreditCart creditCart)
        {           
            string response = _worldPayWebService.Charge(amount, creditCart, BankID, DomenID);
            return response;
        }
    }
}