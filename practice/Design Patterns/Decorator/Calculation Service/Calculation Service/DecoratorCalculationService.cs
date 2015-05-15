namespace Epam.Mentoring.Patterns.Decorator.CalculationService
{
    internal class DecoratorCalculationService : ICalculationService
    {
        protected readonly ICalculationService calculationService;

        public DecoratorCalculationService(ICalculationService calculationService)
        {
            this.calculationService = calculationService;
        }

        public virtual decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return calculationService.Calculate(firstParameter, secondParameter);
        }
    }
}