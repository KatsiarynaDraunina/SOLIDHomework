using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Exceptions;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment.PaymentType;
using SOLIDHomework.Core.Services;
using System;
using System.Configuration;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public class PaymentService: IPaymentService
    {      
        private readonly IPaymentFactory _paymentFactory;
                
        public PaymentService(IPaymentFactory paymentFactory)
        {            
            _paymentFactory = paymentFactory;
        }

        public void ChargeCard(PaymentDetails paymentDetails, IShoppingCartService cart)
        {
            PaymentServiceType paymentServiceType;
            Enum.TryParse(ConfigurationManager.AppSettings["paymentType"], out paymentServiceType);
            try
            {
                var paymentService = _paymentFactory.GetPaymentHandler(paymentServiceType);              
                string serviceResponse = paymentService.Charge(cart.TotalAmount(), new CreditCart()
                {
                    CardNumber = paymentDetails.CreditCardNumber,
                    ExpiryDate = paymentDetails.ExpiryDate,
                    NameOnCard = paymentDetails.CardholderName
                });

                if (!serviceResponse.Contains("200OK") && !serviceResponse.Contains("Success"))
                {
                    throw new Exception(String.Format("Error on charge : {0}", serviceResponse));
                }
            }
            catch (AccountBalanceMismatchException ex)
            {
                throw new OrderException("The card gateway rejected the card based on the address provided.", ex);
            }
            catch (Exception ex)
            {
                throw new OrderException("There was a problem with your card.", ex);
            }
        }
    }
}
