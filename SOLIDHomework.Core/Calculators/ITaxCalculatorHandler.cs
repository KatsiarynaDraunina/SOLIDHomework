namespace SOLIDHomework.Core.Calculators
{
    public interface ITaxCalculatorHandler
    {
        decimal CalculateTax(decimal total);
        bool isApplicable(string country);
    }
}
