using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public interface IPaymentMethodFactory
    {
        PaymentMethodBase GetPaymentMethod(IShoppingCartService shoppingCart, bool notifyCustomer);
    }
}