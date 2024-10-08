using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public interface ITaxCalculateFactory
    {
        void RegisterHandler(ITaxCalculatorHandler handler);
        ITaxCalculatorHandler GetTaxCalculatorHandler();       
    }
}