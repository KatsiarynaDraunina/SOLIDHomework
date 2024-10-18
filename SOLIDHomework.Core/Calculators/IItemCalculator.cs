namespace SOLIDHomework.Core.Calculators
{
    public interface IItemCalculator
    {
        void RegisterHandler(IOrderItemTypeHandler handler);
        decimal CalculateItemTotal(OrderItem orderItem);
    }
}
