using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public interface IPaymentService
    {
        void ChargeCard(PaymentDetails paymentDetails, IShoppingCartService cart);
    }
}
