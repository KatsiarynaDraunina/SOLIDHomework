using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public class TaxCalculator : ITaxCalculatorHandler
    {
        private decimal NonUsSurcharge = 1.1M;

        public bool isApplicable(string country)
        {
            return country != "US";
        }

        public decimal CalculateTax(decimal total)
        {
            return total * NonUsSurcharge;
        }
    }
}
