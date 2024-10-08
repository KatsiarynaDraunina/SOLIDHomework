namespace SOLIDHomework.Core.Calculators
{
    public class WeightOrderItemTypeHandler: IOrderItemTypeHandler
    {
        public bool IsApplicable(string orderItemType)
        {
            return orderItemType == "Weight";
        }

        public decimal Calculate(OrderItem orderItem)
        {
            return orderItem.Amount * orderItem.Price / 1000M;            
        }
    }
}
