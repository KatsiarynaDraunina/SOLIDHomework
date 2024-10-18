namespace SOLIDHomework.Core.Calculators
{
    public interface IDiscountCalculator
    {
        decimal CalculateUnitDiscount(OrderItem orderItem);
    }
}
