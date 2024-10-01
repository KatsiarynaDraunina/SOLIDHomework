using SOLIDHomework.Core.Calculators;
using SOLIDHomework.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace SOLIDHomework.Core
{
    // Consider adding interfaces for factories
    public class TaxCalculateFactory: ITaxCalculateFactory
    {        
        private List<ITaxCalculatorHandler> _listOfTaxCalculatotHandlers = new List<ITaxCalculatorHandler>();
        private readonly IUserService _userService;
        public TaxCalculateFactory(IUserService userService)
        {
            _userService = userService;
        }

        public void RegisterHandler(ITaxCalculatorHandler handler)
        {
            if (!_listOfTaxCalculatotHandlers.Contains(handler))
            {
                _listOfTaxCalculatotHandlers.Add(handler);
            }
        }

        public ITaxCalculatorHandler GetTaxCalculatorHandler()
        {            
            var country = _userService.GetCountry();
            var handler = _listOfTaxCalculatotHandlers.First(h => h.isApplicable(country));

            return handler;
        }     
    }
}
