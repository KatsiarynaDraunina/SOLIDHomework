namespace SOLIDHomework.Core.Calculators
{
    public interface ITaxCalculatorHandler
    {
        decimal CalculateTax(decimal total);
        bool IsApplicable(string country);
    }
}
