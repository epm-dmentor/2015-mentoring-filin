namespace Epam.Mentoring.Patterns.Decorator.Calculator
{
    internal class Multiply : IOperation
    {
        private readonly IOperation operand1;
        private readonly IOperation operand2;

        public Multiply(IOperation operand1, IOperation operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public double Calculate()
        {
            return operand1.Calculate()*operand2.Calculate();
        }
    }
}