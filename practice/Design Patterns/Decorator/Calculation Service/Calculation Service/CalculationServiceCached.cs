#region

using System;
using System.Globalization;
using System.Runtime.Caching;

#endregion

namespace Epam.Mentoring.Patterns.Decorator.CalculationService
{
    internal class CachedCalculationService : DecoratorCalculationService
    {
        private readonly MemoryCache cached;

        public CachedCalculationService(ICalculationService calculationService)
            : base(calculationService)
        {
            cached = new MemoryCache("CalculationService");
        }

        public override decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return CacheResults(firstParameter, secondParameter);
        }

        private decimal CacheResults(decimal firstParameter, decimal secondParameter)
        {
            string getHash = HashChecks(firstParameter, secondParameter);

            if (cached.Contains(getHash))
            {
                return (decimal) cached[getHash];
            }

            decimal calculation = calculationService.Calculate(firstParameter, secondParameter);
            cached.Add(getHash, calculation, DateTimeOffset.MaxValue);
            return calculation;
        }

        private static string HashChecks(decimal firstParameter, decimal secondParameter)
        {
            return Math.Abs(firstParameter.GetHashCode() + secondParameter.GetHashCode())
                    .ToString(CultureInfo.InvariantCulture);
        }
    }
}