using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLIDHomework.Core.Calculators
{
    public class ItemCalculator : IItemCalculator
    {
        private List<IOrderItemTypeHandler> _listOfOrderItemTypes = new List<IOrderItemTypeHandler>();        

        public void RegisterHandler(IOrderItemTypeHandler handler)
        {
            if(!_listOfOrderItemTypes.Contains(handler))
            {
                _listOfOrderItemTypes.Add(handler);
            }
        }

        public decimal CalculateItemTotal(OrderItem orderItem)
        {            
            var handler = _listOfOrderItemTypes.FirstOrDefault(h => h.IsApplicable(orderItem.Type));

            if(handler == null)
            {
                throw new InvalidOperationException($"Incorrect order item type: {orderItem.Type}");
            }

            return handler.Calculate(orderItem);
        }       
    }
}
