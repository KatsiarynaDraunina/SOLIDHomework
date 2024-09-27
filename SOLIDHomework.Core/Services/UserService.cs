using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core.Services
{
    public class UserService : IUserService
    {
        // that is Database-based service 
        private Account _registeredUser;        

        public void RegisterUser(string username, string email, string country, string cardholderName,
            string creditCardNumber, DateTime expiryDate, PaymentMethod paymentMethod)
        {
            _registeredUser = new Account()
            {
                Username = username,
                Email = email,
                Country = country,
                PaymentDetails = new PaymentDetails()
                {
                    CardholderName = cardholderName,
                    CreditCardNumber = creditCardNumber,
                    ExpiryDate = expiryDate,
                    PaymentMethod = paymentMethod
                }
            };
        }

        public Account GetRegisteredUser()
        {
            return _registeredUser;
        }

        public string GetCountry()
        {
            return _registeredUser.Country;
        }

        public PaymentDetails GetPaymentDetails()
        {
            return _registeredUser.PaymentDetails;
        }
    }
}
