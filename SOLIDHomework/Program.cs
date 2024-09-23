using Microsoft.Extensions.DependencyInjection;
using SOLIDHomework.Core;
using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;
using System;

namespace SOLIDHomework
{
    public class Program
    {
        //Entry point to program
        //You don't have to change logic there
        //Tip: that is good place for composition root
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<>();

            OrderService orderService = new OrderService()
            {
                Inventory = new Inventory(),
                Logger = new MyLogger(),
                NotificationService = new NotificationService(),
                PaymentService = new PaymentService()
            };

            ShoppingCartService shoppingCart = new ShoppingCartService("US");
            shoppingCart._itemCalculator = new ItemCalculator();
            shoppingCart._taxCalculator = new TaxCalculateFactory().GetTaxCalculator(shoppingCart.Country);

            shoppingCart.Add(new OrderItem()
                {
                    Amount = 1,
                    SeassonEndDate =  DateTime.Now,
                    Code =  "Test",
                    Price =  10,
                    Type = "Unit"
                });
            orderService.Checkout("TestUser",shoppingCart,new PaymentDetails()
                {
                   CardholderName = "haha",
                   CreditCardNumber =  "41111111111111",
                   ExpiryDate =  DateTime.Now.AddDays(10),
                   PaymentMethod = PaymentMethod.Cash
                },true);
        }
    }
}
