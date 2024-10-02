using SOLIDHomework.Core.Calculators;
using System.Collections.Generic;

namespace SOLIDHomework.Core.Services
{
    // Remove unused properties
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<OrderItem> orderItems;
        private readonly IUserService _userService;
        private readonly IItemCalculator _itemCalculator;
        private readonly ITaxCalculateFactory _taxCalculateFactory;              

        public ShoppingCartService(IItemCalculator itemCalculator, ITaxCalculateFactory taxCalculatFactory, IUserService userService)
        {            
            orderItems = new List<OrderItem>();
            _taxCalculateFactory = taxCalculatFactory;
            _itemCalculator= itemCalculator;           
            _userService = userService;
        }
        
        public IEnumerable<OrderItem> OrderItems
        {
            get { return orderItems; }
        }

        public void Add(OrderItem orderItem)
        {
            orderItems.Add(orderItem);
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
