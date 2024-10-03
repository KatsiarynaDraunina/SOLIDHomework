using SOLIDHomework.Core.Calculators;
using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.Services;
using System;
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
            var country = _userService.GetRegisteredUser().Country;
            var handler = _listOfTaxCalculatotHandlers.FirstOrDefault(h => h.IsApplicable(country));

            if (handler == null)
            {
                throw new InvalidOperationException($"No tax calculator found for country: {country}");
            }

            return handler;
        }     
    }
}
