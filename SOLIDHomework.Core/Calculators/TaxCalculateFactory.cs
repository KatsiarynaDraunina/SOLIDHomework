using SOLIDHomework.Core.Calculators;
using SOLIDHomework.Core.Services;

namespace SOLIDHomework.Core
{
    // Consider adding interfaces for factories
    public class TaxCalculateFactory: ITaxCalculateFactory
    {
        private readonly IUserService _userService;

        public TaxCalculateFactory(IUserService userService)
        {
            _userService = userService;
        }


        // Consider moving from IF/ESLE mechanism in factories
        public ITaxCalculator GetTaxCalculator(string country)
        {            
            switch (country)
            {
                case "US":
                    return new USTaxCalculator();
                default:
                    return new TaxCalculator();
            }
        }
    }
}
