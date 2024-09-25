using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    // Consider adding interfaces for factories
    public class TaxCalculateFactory
    {
        // Consider moving from IF/ESLE mechanism in factories
        public ITaxCalculator GetTaxCalculator(string country)
        {
            if (country != "US")
            {
                return new TaxCalculator();
            }
            else
            {
                return new USTaxCalculator();
            }
        }
    }
}
