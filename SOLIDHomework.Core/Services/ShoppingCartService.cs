using SOLIDHomework.Core.Calculators;
using System.Collections.Generic;

namespace SOLIDHomework.Core.Services
{
    //there are OCP and SOC violation
    //
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly List<OrderItem> orderItems;
        public string Country { get; }
        private readonly IItemCalculator _itemCalculator;
        private readonly ITaxCalculator _taxCalculator;

        public ShoppingCartService(string country, IItemCalculator itemCalculator, ITaxCalculator taxCalculator)
        {
            Country = country;
            orderItems = new List<OrderItem>();
            _taxCalculator = taxCalculator;
            _itemCalculator= itemCalculator;
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

            total = _taxCalculator.CalculateTax(total);

            return total;
        }
    }
}
