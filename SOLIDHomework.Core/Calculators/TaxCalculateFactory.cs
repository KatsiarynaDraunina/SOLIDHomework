using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public class TaxCalculateFactory
    {
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
