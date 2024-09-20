using System;
using System.Collections.Generic;

namespace SOLIDHomework.Core
{
    //there are OCP and SOC violation
    //
    public class ShoppingCart
    {
        private readonly string country;
        private readonly List<OrderItem> orderItems;
        private IItemCalculator _itemCalculator; 
        private SurchargeApplierFactory _surchargeFactory = new SurchargeApplierFactory();

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
           
            var surchargeApplier = _surchargeFactory.GetSurchargeApplier(country);
            total = surchargeApplier.ApplySurcharge(total);

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

    public interface ISurchargeApplier
    {
        decimal ApplySurcharge(decimal total);
    }

    public class UsSurchargeApplier : ISurchargeApplier
    {
        private decimal UsSurcharge = 1.2M;

        public decimal ApplySurcharge(decimal total)
        {
            return total * UsSurcharge;
        }
    }

    public class SurchargeApplier : ISurchargeApplier
    {
        private decimal NonUsSurcharge = 1.1M;

        public decimal ApplySurcharge(decimal total)
        {
            return total * NonUsSurcharge;
        }
    }

    public class SurchargeApplierFactory
    {
        public ISurchargeApplier GetSurchargeApplier(string country)
        {
            if (country != "US")
            {
                return new SurchargeApplier();
            }
            else
            {
                return new UsSurchargeApplier();
            }
        }
    }
}
