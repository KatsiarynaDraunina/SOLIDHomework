using System;
using System.Collections.Generic;

namespace SOLIDHomework.Core
{
    //there are OCP and SOC violation
    //
    public class ShoppingCart
    {       
        private readonly List<OrderItem> orderItems;
        public string Country { get; }
        public IItemCalculator ItemCalculator { get; set; }
        public ITaxCalculator TaxCalculator { get; set; }

        public ShoppingCart(string country)
        {
            Country = country;
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
                total += ItemCalculator.CalculateItemTotal(orderItem);
            }
            
            total = TaxCalculator.CalculateTax(total);

            return total;
        }            
    }

    public interface IItemCalculator
    {
        decimal CalculateItemTotal(OrderItem orderItem);
    }

    public class ItemCalculator : IItemCalculator 
    {
        private IDiscountCalculator _discountCalculator;
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
            else if(orderItem.Type == "Weight")
            {
                itemTotal = orderItem.Amount * orderItem.Price / 1000M;
            }

            return itemTotal;
        }
    }

    public interface IDiscountCalculator
    {
        decimal CalculateUnitDiscount(OrderItem orderItem);
    }

    public class DiscountCalculator: IDiscountCalculator
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

    public interface ITaxCalculator
    {
        decimal CalculateTax(decimal total);
    }

    public class USTaxCalculator : ITaxCalculator
    {
        private decimal UsSurcharge = 1.2M;

        public decimal CalculateTax(decimal total)
        {
            return total * UsSurcharge;
        }
    }

    public class TaxCalculator : ITaxCalculator
    {
        private decimal NonUsSurcharge = 1.1M;

        public decimal CalculateTax(decimal total)
        {
            return total * NonUsSurcharge;
        }
    }

    public class TaxCalculateFactory
    {
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
