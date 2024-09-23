namespace SOLIDHomework.Core.Calculators
{
    public interface IItemCalculator
    {
        decimal CalculateItemTotal(OrderItem orderItem);
    }
}
