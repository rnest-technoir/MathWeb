using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MathService.PrimeNumbers
{
    public class ParallelPrimeNumberCalculationStrategy : SimplePrimeNumberCalculationStrategy
    {
        public override IEnumerable<int> Calculate(int min, int max)
        {
            return new HashSet<int>(
                Enumerable.Range(min, max)
                .AsParallel()
                .Where(num => IsPrime(num))                
                .ToList()
                );
        }
    }
}
