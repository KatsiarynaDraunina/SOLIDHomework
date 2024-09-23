using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public class TaxCalculator : ITaxCalculator
    {
        private decimal NonUsSurcharge = 1.1M;

        public decimal CalculateTax(decimal total)
        {
            return total * NonUsSurcharge;
        }
    }
}
