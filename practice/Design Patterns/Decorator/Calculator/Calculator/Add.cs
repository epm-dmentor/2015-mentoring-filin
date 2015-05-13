namespace Calculator
{
    internal class Add : IOperation
    {
        private readonly IOperation operand1;
        private readonly IOperation operand2;

        public Add(IOperation operand1, IOperation operand2)
        {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public double Calculate()
        {
            return operand1.Calculate() + operand2.Calculate();
        }
    }
}