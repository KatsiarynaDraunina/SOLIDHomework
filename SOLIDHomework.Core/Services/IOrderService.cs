using SOLIDHomework.Core.Model;

namespace SOLIDHomework.Core.Services
{
    public interface IOrderService
    {
        void Checkout(IShoppingCartService shoppingCart, bool notifyCustomer);
    }
}