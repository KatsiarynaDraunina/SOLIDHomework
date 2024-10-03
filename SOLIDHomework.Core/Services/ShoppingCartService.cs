using SOLIDHomework.Core.Calculators;
using System.Collections.Generic;

namespace SOLIDHomework.Core.Services{
    
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<OrderItem> _orderItems;       
        private readonly IItemCalculator _itemCalculator;
        private readonly ITaxCalculateFactory _taxCalculateFactory;              

        public ShoppingCartService(IItemCalculator itemCalculator, ITaxCalculateFactory taxCalculatFactory, IUserService userService)
        {            
            _orderItems = new List<OrderItem>();
            _taxCalculateFactory = taxCalculatFactory;
            _itemCalculator= itemCalculator;          
        }
        
        public IEnumerable<OrderItem> OrderItems
        {
            get { return _orderItems; }
        }

        public void Add(OrderItem orderItem)
        {
            _orderItems.Add(orderItem);
        }

        public decimal TotalAmount()
        {
            decimal total = 0;

            foreach (var orderItem in OrderItems)
            {
                total += _itemCalculator.CalculateItemTotal(orderItem);
            }

            total = _taxCalculateFactory.GetTaxCalculatorHandler().CalculateTax(total);

            return total;
        }
    }
}
