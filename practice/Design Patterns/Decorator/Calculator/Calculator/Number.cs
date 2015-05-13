namespace Calculator
{
    internal class Number : IOperation
    {
        private readonly double number;

        public Number(double number)
        {
            this.number = number;
        }

        public double Calculate()
        {
            return number;
        }
    }
}