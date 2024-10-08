namespace SOLIDHomework.Core.Calculators
{
    public interface IOrderItemTypeHandler
    {
        bool IsApplicable(string orderItemType);
        decimal Calculate(OrderItem orderItem);       
    }
}
