using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathService.PrimeNumbers
{
    public class PrimeNumbersGenerator : IPrimeNumbersGenerator
    {
        protected readonly IPrimeNumberCalculationStrategy _strategy;

        public PrimeNumbersGenerator(IPrimeNumberCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        protected virtual bool IsPrime(int n) => _strategy.IsPrime(n);

        public virtual IEnumerable<int> Calculate(int min = 0, int max = int.MaxValue) => _strategy.Calculate(min, max);
        public virtual async Task<IEnumerable<int>> CalculateAsync(int min = 0, int max = int.MaxValue) => await Task.Run(() => _strategy.Calculate(min, max));

    }
}
