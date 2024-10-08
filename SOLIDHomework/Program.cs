using Microsoft.Extensions.DependencyInjection;
using SOLIDHomework.Core;
using SOLIDHomework.Core.Calculators;
using SOLIDHomework.Core.Enums;
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
            services.AddScoped<IWorldPayWebService, WorldPayWebService>();
            services.AddScoped<IPayPalWebService, PayPalWebService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IDiscountCalculator, DiscountCalculator>();
            services.AddScoped<IItemCalculator, ItemCalculator>();
            services.AddScoped<ITaxCalculateFactory, TaxCalculateFactory>();
            services.AddScoped<IPaymentMethodFactory, PaymentMethodFactory>();
            services.AddScoped<IPaymentFactory, PaymentFactory>();
            services.AddScoped<IPaymentHandler, PayPalPaymentHandler>();
            services.AddScoped<IPaymentHandler, WorldPayPaymentHandler>();
            services.AddScoped<IPaymentMethodHandler, CreditCardPayment>();
            services.AddScoped<IPaymentMethodHandler, OnlineOrderPayment>();
            services.AddScoped<ITaxCalculatorHandler, TaxCalculator>();
            services.AddScoped<ITaxCalculatorHandler, USTaxCalculator>();
            services.AddScoped<IOrderItemTypeHandler, UnitOrderItemTypeHandler>();
            services.AddScoped<IOrderItemTypeHandler, SpecialOrderItemTypeHandler>();
            services.AddScoped<IOrderItemTypeHandler, WeightOrderItemTypeHandler>();

            var serviceProvider = services.BuildServiceProvider();          

            var orderService = serviceProvider.GetService<IOrderService>();  
            var shoppingCart = serviceProvider.GetService<IShoppingCartService>();           
            var userService = serviceProvider.GetService<IUserService>();

            var paymentFactory = serviceProvider.GetService<IPaymentFactory>();
            var paymentHandlers = serviceProvider.GetServices<IPaymentHandler>();            
            foreach (var handler in paymentHandlers)
            {
                paymentFactory.RegisterHandler(handler);
            }            

            var paymentMethodFactory = serviceProvider.GetService<IPaymentMethodFactory>();
            var paymentMethodHandlers = serviceProvider.GetServices<IPaymentMethodHandler>();
            foreach (var handler in paymentMethodHandlers)
            {
                paymentMethodFactory.RegisterHandler(handler);
            }           

            var taxCalculateFactory = serviceProvider.GetService<ITaxCalculateFactory>();
            var taxCalculateHandlers = serviceProvider.GetServices<ITaxCalculatorHandler>();
            foreach (var handler in taxCalculateHandlers)
            {
                taxCalculateFactory.RegisterHandler(handler);
            }           

            var itemCalculator = serviceProvider.GetService<IItemCalculator>();
            var orderItemHandlers = serviceProvider.GetServices<IOrderItemTypeHandler>();
            foreach (var handler in orderItemHandlers)
            {
                itemCalculator.RegisterHandler(handler);
            }           

            // Add a UserService where we will register our user            
            shoppingCart.Add(new OrderItem()
                {
                    Amount = 1,
                    SeassonEndDate =  DateTime.Now,
                    Code =  "Test",
                    Price =  10,
                    Type = "Unit"
                });
            userService.RegisterUser("TestUser", "test@test.com", "US", "haha", "41111111111111", DateTime.Now.AddDays(10), PaymentMethod.OnlineOrder);
            orderService.Checkout(shoppingCart,true);
        }
    }
}
