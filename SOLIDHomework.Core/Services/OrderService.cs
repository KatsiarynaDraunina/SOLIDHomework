using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment.PaymentMethod;

namespace SOLIDHomework.Core.Services
{
    public class OrderService: IOrderService
    {
        private readonly IInventory _inventory;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;
        private readonly IPaymentService _paymentService;

        public OrderService(IInventory inventory, ILogger logger, INotificationService notificationService, IPaymentService paymentService)
        {
            _inventory = inventory;
            _logger = logger;
            _notificationService = notificationService;
            _paymentService = paymentService;
        }

        public void Checkout(string username, IShoppingCartService shoppingCart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            // Try moving payment method factory to the constructor 
            var paymentMethodFactory = new PaymentMethodFactory(_paymentService, _notificationService);
            paymentMethodFactory.GetPaymentMethod(paymentDetails, shoppingCart, username, notifyCustomer);
            _inventory.ReserveInventory(shoppingCart);
            _logger.Write("Success checkout");
        }
    }
}
