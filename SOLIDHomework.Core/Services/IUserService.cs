using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core.Services
{
    public interface IUserService
    {        
        void RegisterUser(string username, string email, string country, string cardholderName,
           string creditCardNumber, DateTime expiryDate, PaymentMethod paymentMethod);
        Account GetRegisteredUser();        
    }
}
