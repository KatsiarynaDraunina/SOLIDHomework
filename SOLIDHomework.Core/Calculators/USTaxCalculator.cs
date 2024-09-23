using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public class USTaxCalculator : ITaxCalculator
    {
        private decimal UsSurcharge = 1.2M;

        public decimal CalculateTax(decimal total)
        {
            return total * UsSurcharge;
        }
    }
}
