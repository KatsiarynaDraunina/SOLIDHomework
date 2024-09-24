namespace SOLIDHomework.Core.Calculators
{
    public class ItemCalculator : IItemCalculator
    {
        private readonly IDiscountCalculator _discountCalculator;

        public ItemCalculator(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

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
            else if (orderItem.Type == "Weight")
            {
                itemTotal = orderItem.Amount * orderItem.Price / 1000M;
            }

            return itemTotal;
        }
    }
}
