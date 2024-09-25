using SOLIDHomework.Core.Calculators;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core
{
    // Consider adding interfaces for factories
    public class TaxCalculateFactory: ITaxCalculateFactory
    {
        public readonly IUserService _userService;

        public TaxCalculateFactory(IUserService userService)
        {
            _userService = userService;
        }

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
