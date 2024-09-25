using Microsoft.Extensions.DependencyInjection;
using SOLIDHomework.Core;
using SOLIDHomework.Core.Calculators;
using SOLIDHomework.Core.Enums;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment.PaymentMethod;
using SOLIDHomework.Core.Payment.PaymentType;
using SOLIDHomework.Core.Services;
using System;

namespace SOLIDHomework
{
    public class Program
    {
        // Run the program, if it fails, fix the build
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<ILogger, MyLogger>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IInventory, Inventory>();
            services.AddScoped<IWorldPayWebService, WorldPayWebService>();
            services.AddScoped<IPayPalWebService, PayPalWebService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IDiscountCalculator, DiscountCalculator>();
            services.AddScoped<IItemCalculator, ItemCalculator>();
            services.AddScoped<ITaxCalculator, TaxCalculator>();
            services.AddScoped<IPaymentMethodFactory, PaymentMethodFactory>();

            var serviceProvider = services.BuildServiceProvider();          

            var orderService = serviceProvider.GetService<IOrderService>();  
            var shoppingCart = serviceProvider.GetService<IShoppingCartService>();
          //  shoppingCart.Country = "US";

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
