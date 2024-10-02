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

            var serviceProvider = services.BuildServiceProvider();          

            var orderService = serviceProvider.GetService<IOrderService>();  
            var shoppingCart = serviceProvider.GetService<IShoppingCartService>();
            var paymentService = serviceProvider.GetService<IPaymentService>();           
            var userService = serviceProvider.GetService<IUserService>();

            var paymentFactory = serviceProvider.GetService<IPaymentFactory>();
            var payPalHandler = new PayPalPaymentHandler(serviceProvider.GetService <IPayPalWebService> ());
            var worldPayHandler = new WorldPayPaymentHandler(serviceProvider.GetService<IWorldPayWebService>());
            paymentFactory.RegisterHandler(payPalHandler);
            paymentFactory.RegisterHandler(worldPayHandler);

            var paymentMethodFactory = serviceProvider.GetService<IPaymentMethodFactory>();
            var creditCardPayment = new CreditCardPayment(paymentService);
            var onlineOrderPayment = new OnlineOrderPayment(paymentService);
            paymentMethodFactory.RegisterHandler(onlineOrderPayment);
            paymentMethodFactory.RegisterHandler(creditCardPayment);

            var taxCalculatrFactory = serviceProvider.GetService<ITaxCalculateFactory>();
            taxCalculatrFactory.RegisterHandler(new TaxCalculator());
            taxCalculatrFactory.RegisterHandler(new USTaxCalculator());

            var itemCalculator = serviceProvider.GetService<IItemCalculator>();
            var unitOrderItemTypeHandler = new UnitOrderItemTypeHandler(serviceProvider.GetService<IDiscountCalculator>());
            var specialOrderItemTypeHandler = new SpecialOrderItemTypeHandler();
            var weightOrderItemTypeHandler = new WeightOrderItemTypeHandler();
            itemCalculator.RegisterHandler(unitOrderItemTypeHandler);
            itemCalculator.RegisterHandler(specialOrderItemTypeHandler);
            itemCalculator.RegisterHandler(weightOrderItemTypeHandler);

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
