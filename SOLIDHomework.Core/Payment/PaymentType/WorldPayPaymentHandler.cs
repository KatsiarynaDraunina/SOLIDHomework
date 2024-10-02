﻿using SOLIDHomework.Core.Enums;
using System.Configuration;

namespace SOLIDHomework.Core.Payment.PaymentType
{
    public class WorldPayPaymentHandler : IPaymentHandler
    {
        //required for Auth;
        public string BankID { get; set; }
        public string DomenID { get; set; }

        private readonly IWorldPayWebService _worldPayWebService;
        public WorldPayPaymentHandler( IWorldPayWebService worldPayWebService)
        {
            _worldPayWebService = worldPayWebService;
        }
        // Update naming according to the Name Convention
        public bool isApplicable(PaymentServiceType paymentServiceType)
        {
            return paymentServiceType == PaymentServiceType.WorldPay;
        }

        public string Charge(decimal amount, CreditCart creditCart)
        {           
            string response = _worldPayWebService.Charge(amount, creditCart, ConfigurationManager.AppSettings["BankID"], DomenID);
            return response;
        }
    }
}