using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public interface ITaxCalculateFactory
    {
        ITaxCalculator GetTaxCalculator(string country);
    }
}