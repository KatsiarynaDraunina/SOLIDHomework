using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core
{
    //there are OCP and SOC violation
    //
    public class ShoppingCart
    {
        private readonly string country;
        private readonly List<OrderItem> orderItems;
        private ItemCalculator _itemCalculator = new ItemCalculator(); 
        private CountrySurchargeApplier _countrySurchargeApplier = new CountrySurchargeApplier();

        public ShoppingCart(string country)
        {
            this.country = country;
            orderItems = new List<OrderItem>();
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

            total = _countrySurchargeApplier.ApplyCountrySurcharge(total, country);

            return total;
        }            
    }

    public class ItemCalculator
    {
        private DiscountCalculator _discountCalculator = new DiscountCalculator();
        public decimal CalculateItemTotal(OrderItem orderItem)
        {
            decimal itemTotal = 0;

            if (orderItem.Type == "Unit")
            {
                decimal unitDiscount = _discountCalculator.CalculateUnitDiscount(orderItem);
                itemTotal = orderItem.Amount * orderItem.Price * (1 - unitDiscount / 100m);
            }
            //when buy 4 prodcuts - get one for free!
            else if (orderItem.Type == "Special")
            {
                itemTotal = orderItem.Amount * orderItem.Price;
                int setsOfFour = orderItem.Amount / 4;
                itemTotal -= setsOfFour * orderItem.Price;
            }

            return itemTotal;
        }
    }

    public class DiscountCalculator
    {
        public decimal CalculateUnitDiscount(OrderItem orderItem)
        {
            if (orderItem.SeassonEndDate <= DateTime.Now)
            {
                return 20; // 20% discount for old seasons
            }
            return 0;
        }
    }

    public class CountrySurchargeApplier
    {
        public decimal ApplyCountrySurcharge(decimal total, string country)
        {
            decimal usSurcharge = 1.2M;
            decimal nonUsSurcharge = 1.1M;

            return country == "US" ? total * usSurcharge : total * nonUsSurcharge;
        }
    }

}
