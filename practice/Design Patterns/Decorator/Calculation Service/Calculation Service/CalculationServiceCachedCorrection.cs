namespace Epam.Mentoring.Patterns.Decorator.CalculationService
{
    internal class CorrectedCalculationService : DecoratorCalculationService
    {
        public CorrectedCalculationService(ICalculationService calc)
            : base(calc)
        {
        }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return calculationService.Calculate(firstParameter, secondParameter) + 10;
        }
    }
}