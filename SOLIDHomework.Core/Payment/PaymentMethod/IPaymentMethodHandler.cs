using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core.Payment.PaymentMethod
{
    public interface IPaymentMethodHandler
    {
        bool isApplicable(Enums.PaymentMethod paymentMethod);
        void ProcessPayment();
    }
}
