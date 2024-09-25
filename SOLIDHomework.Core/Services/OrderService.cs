using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Payment.PaymentMethod;

namespace SOLIDHomework.Core.Services
{
    public class OrderService: IOrderService
    {
        private readonly IInventory _inventory;
        private readonly ILogger _logger;       
        private readonly IPaymentMethodFactory _paymentMethodFactory;        

        public OrderService(IInventory inventory, ILogger logger, IPaymentMethodFactory paymentMethodFactory)
        {
            _inventory = inventory;
            _logger = logger;           
            _paymentMethodFactory= paymentMethodFactory;           
        }

        public void Checkout(string username, IShoppingCartService shoppingCart, bool notifyCustomer)
        {
            // Try moving payment method factory to the constructor           
            _paymentMethodFactory.GetPaymentMethod(string username, shoppingCart, notifyCustomer).ProcessPayment();
            _inventory.ReserveInventory(shoppingCart);
            _logger.Write("Success checkout");
        }
    }
}
