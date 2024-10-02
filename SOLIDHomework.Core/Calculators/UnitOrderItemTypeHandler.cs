namespace SOLIDHomework.Core.Calculators
{
    public class UnitOrderItemTypeHandler: IOrderItemTypeHandler
    {
        private readonly IDiscountCalculator _discountCalculator;

        public UnitOrderItemTypeHandler(IDiscountCalculator discountCalculator)
        {
            _discountCalculator = discountCalculator;
        }

        public bool IsApplicable(string orderItemType)
        {
            return orderItemType == "Unit";
        }

        public decimal Calculate(OrderItem orderItem)
        {  
            decimal unitDiscount = _discountCalculator.CalculateUnitDiscount(orderItem);
            return orderItem.Amount * orderItem.Price * (1 - unitDiscount / 100m);            
        }
    }
}
