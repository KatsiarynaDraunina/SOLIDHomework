using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Model;
using System;

namespace SOLIDHomework.Core.Services
{
    public class UserService : IUserService
    {
        // that is Database-based service 
        public Account GetByUsername(string username)
        {
            return new Account()
            {
                Username = "TestUser",
                Email = "test@test.com", 
                Country = "US", 
                PaymentDetails= new PaymentDetails() 
                {
                    CardholderName = "haha",
                    CreditCardNumber = "41111111111111",
                    ExpiryDate = DateTime.Now.AddDays(10),
                    PaymentMethod = PaymentMethod.OnlineOrder
                }
            };
        }       
    }        
}