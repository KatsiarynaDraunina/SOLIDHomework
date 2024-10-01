using SOLIDHomework.Core.Calculators;

namespace SOLIDHomework.Core
{
    public class USTaxCalculator : ITaxCalculatorHandler
    {
        private decimal UsSurcharge = 1.2M;

        public bool isApplicable(string country)
        {
            return country == "US";
        }

        public decimal CalculateTax(decimal total)
        {
            return total * UsSurcharge;
        }
    }
}
