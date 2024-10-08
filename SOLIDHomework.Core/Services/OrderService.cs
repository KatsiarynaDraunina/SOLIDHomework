using SOLIDHomework.Core.Payment.PaymentMethod;

namespace SOLIDHomework.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IInventoryService _inventory;
        private readonly ILogger _logger;       
        private readonly IPaymentMethodFactory _paymentMethodFactory;
        private readonly INotificationService _notificationService;

        public OrderService(IInventoryService inventory, ILogger logger, IPaymentMethodFactory paymentMethodFactory, INotificationService notificationService)
        {
            _inventory = inventory;
            _logger = logger;           
            _paymentMethodFactory = paymentMethodFactory;
            _notificationService = notificationService;
        }

        public void Checkout(IShoppingCartService shoppingCart, bool notifyCustomer)
        {        
            _paymentMethodFactory.GetPaymentHandler().ProcessPayment();

            if (notifyCustomer)
            {
                _notificationService.NotifyCustomer();
            }

            _inventory.ReserveInventory(shoppingCart);
            _logger.LogInformation("Success checkout");
        }
    }
}
