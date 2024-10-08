using System;

namespace SOLIDHomework.Core.Calculators
{
    public class DiscountCalculator : IDiscountCalculator
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
}
