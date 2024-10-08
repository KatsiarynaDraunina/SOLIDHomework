namespace SOLIDHomework.Core.Calculators
{
    public class SpecialOrderItemTypeHandler: IOrderItemTypeHandler
    {
        public bool IsApplicable(string orderItemType)
        {
            return orderItemType == "Special";
        }

        public decimal Calculate(OrderItem orderItem)
        {
            var itemTotal = orderItem.Amount * orderItem.Price;
            int setsOfFour = orderItem.Amount / 4;
            itemTotal -= setsOfFour * orderItem.Price;

            return itemTotal;
        }                   
    }
}
