namespace SOLIDHomework.Core.Calculators
{
    public class ItemCalculator : IItemCalculator
    {
        private readonly IDiscountCalculator _discountCalculator;

        public ItemCalculator(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        // Consider moving from IF/ESLE mechanism
        public decimal CalculateItemTotal(OrderItem orderItem)
        {
            decimal itemTotal = 0;

            switch (orderItem.Type)
            {
                case "Unit":
                    decimal unitDiscount = _discountCalculator.CalculateUnitDiscount(orderItem);
                    itemTotal = orderItem.Amount * orderItem.Price * (1 - unitDiscount / 100m);
                    break;

                case "Special":
                    itemTotal = orderItem.Amount * orderItem.Price;
                    int setsOfFour = orderItem.Amount / 4;
                    itemTotal -= setsOfFour * orderItem.Price;
                    break;

                case "Weight":
                    itemTotal = orderItem.Amount * orderItem.Price / 1000M;
                    break;
            }
            return itemTotal;
        }
    }
}
