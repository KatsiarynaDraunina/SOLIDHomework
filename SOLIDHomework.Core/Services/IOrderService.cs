using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.Services
{
    public interface IOrderService
    {
        void Checkout(string username, IShoppingCartService shoppingCart, PaymentDetails paymentDetails, bool notifyCustomer);
    }
}